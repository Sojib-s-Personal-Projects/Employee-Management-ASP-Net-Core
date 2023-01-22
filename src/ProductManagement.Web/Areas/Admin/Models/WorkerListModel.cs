using Autofac;
using Infrastructure.Services;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Models
{
	public class WorkerListModel : BaseModel
	{
        private IWorkerService? _workerService;

        public WorkerListModel(IWorkerService? workerService)
        {
            _workerService = workerService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _workerService = _scope.Resolve<IWorkerService>();
        }

        public object? GetPagedWorkers(DataTablesAjaxRequestModel model)
		{
            
            var data = _workerService.GetWorkers(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] {"Id,User"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                            select new string[]
                            {
                                    record.Roll.ToString(),
                                    record.User
                            }
                        ).ToArray()
            };
        }
	}
}