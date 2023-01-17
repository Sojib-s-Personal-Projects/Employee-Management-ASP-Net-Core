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

        public WorkerInfoService(IApplicationUnitOfWork applicationUnitOfWork,IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<WorkerInfoBO> GetWorkerInformationByRoll(long roll)
        {
            var workerInfoEO= _applicationUnitOfWork.WorkersInformation.Get(x=>x.Roll==roll && x.BarCodeData!=null,"Worker").FirstOrDefault();
            var workerInfoBO=_mapper.Map<WorkerInfoBO>(workerInfoEO);
            return workerInfoBO;
        }

        public async Task InsertData(WorkerInfoBO model)
        {
            var workerInfoEO=_mapper.Map<WorkerInfoEO>(model);
            var worker=_applicationUnitOfWork.Workers.Get(x => x.Roll == workerInfoEO.Roll, "").Select(s => s).FirstOrDefault();
            workerInfoEO.Worker = worker;

            var workerInfoCount = _applicationUnitOfWork.WorkersInformation.Get(x => x.Roll == workerInfoEO.Roll, "").Count;
            if(workerInfoCount>0)
            {
                throw new DataExistsException("This workers data has barcode has already been scanned");
            }

            _applicationUnitOfWork.WorkersInformation.Add(workerInfoEO);
            _applicationUnitOfWork.Save();

        }

        public void InsertPrice(WorkerInfoBO workerInfoBO)
        {
            var workerInfoEO = _applicationUnitOfWork.WorkersInformation.Get(x=>x.Roll== workerInfoBO.Roll,"Worker").FirstOrDefault();
            workerInfoEO.Price = workerInfoBO.Price;
            _applicationUnitOfWork.Save();
        }
    }
}
