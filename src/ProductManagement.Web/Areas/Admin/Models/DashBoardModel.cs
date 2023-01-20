using Autofac;
using Infrastructure.Services;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Models
{
    public class DashBoardModel : BaseModel
    {
        public int UnscannedWorkerCount { get; set; }
        public int PriceNotInsertedWorkersCount { get; set; }

        private IWorkerService? _workerService;

        public DashBoardModel(IWorkerService? workerService)
        {
            _workerService = workerService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _workerService = _scope.Resolve<IWorkerService>();
        }
        
        public async Task GetUnscannedWorkersCount()
        {
            UnscannedWorkerCount = await _workerService.GetUnscannedWorkersCount();
        }

        public async Task GetPriceNotInsertedWorkersCount()
        {
            PriceNotInsertedWorkersCount = await _workerService.GetPriceNotInsertedWorkersCount();
        }
    }
}