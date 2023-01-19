using Autofac;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Models
{
	public class DashBoardModel : BaseModel
	{
        IList<Worker> Workers { get; set; }

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

        public async Task<IList<Worker>> GetWorkersList()
        {
            var workersList = await _workerService.GetWorkerList();
            return workersList;
        }
        public async Task<object?> GetDashboardInfo(DataTablesAjaxRequestModel model)
		{
            
            var data = await _workerService.GetDashboardInfo(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Roll", "User", "Name", "DateOfBirth", "PermanentDistrict", "Quota", "BarCodeData", "Price"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Roll.ToString(),
                                record.User,
                                record.Name,
                                record.DateOfBirth.ToShortDateString(),
                                record.PermanentDistrict,
                                record.Quota,
                                (record.WorkerInfo!=null ) ? record.WorkerInfo.BarCodeData:"<p class=\"text-warning\">Not Inserted</p>",
                                (record.WorkerInfo!=null) ? (record.WorkerInfo.Price!=null) ? record.WorkerInfo.Price.ToString():"<p class=\"text-warning\">Not Inserted</p>":"<p class=\"text-warning\">Not Inserted</p>"
                        }
                    ).ToArray()
            };
        }
	}
}
