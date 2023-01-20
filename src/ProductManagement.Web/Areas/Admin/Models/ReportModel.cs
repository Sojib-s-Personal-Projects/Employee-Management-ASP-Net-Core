using Autofac;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Models
{
    public class ReportModel : BaseModel
    {

        private IWorkerService? _workerService;

        public ReportModel(IWorkerService? workerService)
        {
            _workerService = workerService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _workerService = _scope.Resolve<IWorkerService>();
        }

        public async Task<IList<Worker>> GetWorkersList()
        {
            var workersList = await _workerService.GetWorkerList();
            return workersList;
        }
    }
}
