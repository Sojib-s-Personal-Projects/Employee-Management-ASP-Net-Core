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
            //var model = _mapper.Map<WorkerInfo>(this);
            var model = new WorkerInfo();
            model.Roll = Roll;
            model.BarCodeData=BarCode1;
            await _workerInfoService.InsertData(model);
        }

        public async Task<bool> CheckForSameBarcode()
        {
            if(BarCode1!=BarCode2)
                return false;
            return true;
        }
    }
}
