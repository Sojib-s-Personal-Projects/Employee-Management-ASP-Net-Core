using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.UnitOfWorks;
using WorkerInfoBO = Infrastructure.BusinessObjects.WorkerInfo;
using WorkerInfoEO = Infrastructure.Entities.WorkerInfo;

namespace Infrastructure.Services
{
    public class WorkerInfoService : IWorkerInfoService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;
        private static IList<WorkerInfoBO> workersPriceInfo;

        public WorkerInfoService(IApplicationUnitOfWork applicationUnitOfWork,IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<WorkerInfoBO> GetWorkerInformationByRoll(string barcode)
        {
            var workerInfoEO= _applicationUnitOfWork.WorkersInformation.Get(x=>x.BarCodeData==barcode && x.BarCodeData!=null,"Worker").FirstOrDefault();
            var workerInfoBO=_mapper.Map<WorkerInfoBO>(workerInfoEO);
            return workerInfoBO;
        }

        public async Task InsertData(WorkerInfoBO model)
        {
            var workerInfoEO=_mapper.Map<WorkerInfoEO>(model);
            var worker=_applicationUnitOfWork.Workers.Get(x => x.Id == workerInfoEO.Roll, "").Select(s => s).FirstOrDefault();
            workerInfoEO.Worker = worker;

            var workerInfoCount = _applicationUnitOfWork.WorkersInformation.Get(x => x.Roll == workerInfoEO.Roll, "").Count;
            var barCodeDuplicateCount = _applicationUnitOfWork.WorkersInformation.Get(x => x.BarCodeData == workerInfoEO.BarCodeData, "").Count;

            if (workerInfoCount>0)
            {
                throw new WorkerExistsException("This workers data has barcode has already been scanned");
            }
            if (barCodeDuplicateCount > 0)
            {
                throw new BarCodeExistsException("This bar code has already been scanned");
            }

            _applicationUnitOfWork.WorkersInformation.Add(workerInfoEO);
            _applicationUnitOfWork.Save();

        }

        public void InsertPrice(WorkerInfoBO workerInfoBO)
        {
            int i;
            var hasStringValue = int.TryParse(workerInfoBO.Price.ToString(), out i);

            if(workerInfoBO.Price==null || !hasStringValue)
            {
                throw new PriceNullOrStringException("This value is not valid for price");
            }

            var workerInfoEO = _applicationUnitOfWork.WorkersInformation.Get(x=>x.Roll== workerInfoBO.Roll,"Worker").FirstOrDefault();
            workerInfoEO.Price = workerInfoBO.Price;
            _applicationUnitOfWork.Save();
        }

        public (int total, int totalDisplay, IList<WorkerInfoBO> records) GetWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfoEO> data, int total, int totalDisplay) results = _applicationUnitOfWork
                .WorkersInformation.GetWorkersInformation(pageIndex, pageSize, searchText, orderby);

            IList<WorkerInfoBO> workersInfo = new List<WorkerInfoBO>();
            foreach (WorkerInfoEO workerInfoEO in results.data)
            {
                if (workerInfoEO.Price == null || workerInfoEO.PriceConfirmed==false)
                {
                    workersInfo.Add(new WorkerInfoBO
                    {
                        BarCodeData = workerInfoEO.BarCodeData,
                        Roll = workerInfoEO.Roll,
                        Id = workerInfoEO.Id,
                        Price = workerInfoEO.Price,
                        PriceConfirmed = workerInfoEO.PriceConfirmed
                    });
                }
            }

            results.totalDisplay = workersInfo.Count();
            return (results.total, results.totalDisplay, workersInfo);
        }

        public (int total, int totalDisplay, IList<WorkerInfoBO> records) GetWorkersPriceInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfoEO> data, int total, int totalDisplay) results = _applicationUnitOfWork
                .WorkersInformation.GetWorkersPriceInformation(pageIndex, pageSize, searchText, orderby);

            IList<WorkerInfoBO> workersInfo = new List<WorkerInfoBO>();
            foreach (WorkerInfoEO workerInfoEO in results.data)
            {
                if (workerInfoEO.Price != null && workerInfoEO.PriceConfirmed == false)
                {
                    workersInfo.Add(new WorkerInfoBO
                    {
                        BarCodeData = workerInfoEO.BarCodeData,
                        Roll = workerInfoEO.Roll,
                        Id = workerInfoEO.Id,
                        Price = workerInfoEO.Price,
                        PriceConfirmed=workerInfoEO.PriceConfirmed
                    });
                }
            }
            workersPriceInfo = workersInfo;
            results.totalDisplay = workersInfo.Count();
            return (results.total, results.totalDisplay, workersInfo);
        }

        public (int total, int totalDisplay, IList<WorkerInfoBO> records) GetPriceNotInsertedWorkersInformation(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<WorkerInfoEO> data, int total, int totalDisplay) results = _applicationUnitOfWork
                .WorkersInformation.GetPriceNotInsertedWorkersInformation(pageIndex, pageSize, searchText, orderby);

            IList<WorkerInfoBO> workersInfo = new List<WorkerInfoBO>();
            foreach (WorkerInfoEO workerInfoEO in results.data)
            {
                if (workerInfoEO.Price == null)
                {
                    workersInfo.Add(new WorkerInfoBO
                    {
                        BarCodeData = workerInfoEO.BarCodeData,
                        Roll = workerInfoEO.Roll,
                        Id = workerInfoEO.Id,
                        Price = workerInfoEO.Price,
                        PriceConfirmed = workerInfoEO.PriceConfirmed
                    });
                }
            }

            results.totalDisplay = workersInfo.Count();
            return (results.total, results.totalDisplay, workersInfo);
        }

        public async Task SubmitPrices()
        {
            if (workersPriceInfo.Count==0)
                throw new PriceNullOrStringException("There are no prices inserted");

            foreach(var workerInfoBO in workersPriceInfo)
            {
                var workerInfoEO = _applicationUnitOfWork.WorkersInformation.Get(x => x.Roll == workerInfoBO.Roll,"Worker").FirstOrDefault();
                workerInfoEO.PriceConfirmed = true;
                _applicationUnitOfWork.Save();
            }
        }
    }
}