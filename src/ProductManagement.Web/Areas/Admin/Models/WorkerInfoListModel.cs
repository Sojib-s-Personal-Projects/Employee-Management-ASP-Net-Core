using Autofac;
using Infrastructure.Services;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Models
{
	public class WorkerInfoListModel : BaseModel
	{
        private IWorkerInfoService? _workerInfoService;

        public WorkerInfoListModel(IWorkerInfoService? workerInfoService)
        {
            _workerInfoService = workerInfoService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _workerInfoService = _scope.Resolve<IWorkerInfoService>();
        }

        public object? GetPagedWorkersInforamation(DataTablesAjaxRequestModel model)
		{
            
            var data = _workerInfoService.GetWorkersInformation(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "BarCodeData", /*"User", "Name", "FathersName", "MothersName", "PostName", "DateOfBirth", "PermanentDistrict", "Quota",*/"Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.BarCodeData.ToString(),
                                //record.User,
                                //record.Name,
                                //record.FathersName,
                                //record.MothersName,
                                //record.PostName,
                                //record.DateOfBirth.ToString(),
                                //record.PermanentDistrict,
                                //record.Quota,
                                record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }
    }
}
