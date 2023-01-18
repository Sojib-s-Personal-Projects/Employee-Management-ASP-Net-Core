using Autofac;
using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;
using Microsoft.Build.Framework;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Models
{
    public class WorkerInfoModel : BaseModel
    {
        public Guid Id { get; set; }

        [Required]
        public string BarCode1 { get; set; }

        [Required]
        public string BarCode2 { get; set; }

        [Required]
        public double? Price { get; set; } = null;
        public long Roll { get; set; }
        public Worker Worker { get; set; }

        private IWorkerInfoService? _workerInfoService;
        private IMapper _mapper;

        public WorkerInfoModel()
        {
            
        }

        public WorkerInfoModel(IWorkerInfoService? workerInfoService,IMapper mapper)
        {
            _workerInfoService = workerInfoService;
            _mapper = mapper;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _workerInfoService = _scope.Resolve<IWorkerInfoService>();
        }

        public async Task StoreRoll(long id)
        {
            Roll = id;
        }

        public async Task InserData()
        {
            var model = new WorkerInfo();
            model.BarCodeData = BarCode1;
            model.Roll = Roll;

            await _workerInfoService.InsertData(model);
        }

        public async Task<bool> CheckForSameBarcode()
        {
            if(BarCode1!=BarCode2)
                return false;
            return true;
        }

        public async Task<WorkerInfo> GetWorkerInformationRoll(string barcode)
        {
            return await _workerInfoService.GetWorkerInformationByRoll(barcode);
        }

        public async Task LoadData(string barcode)
        {
            var workerInfo = await _workerInfoService.GetWorkerInformationByRoll(barcode);
            if (workerInfo != null)
            {
                _mapper.Map(workerInfo, this);
            }
        }

        public void InserPrice()
        {
            var model = new WorkerInfo();
            model.Roll = Roll;
            model.BarCodeData = BarCode1;
            model.Price = Price;
            model.Id = Id;
            model.Worker = Worker;

            _workerInfoService.InsertPrice(model);
        }
    }
}
