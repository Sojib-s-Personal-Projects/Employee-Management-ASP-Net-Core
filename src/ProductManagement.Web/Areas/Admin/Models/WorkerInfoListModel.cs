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

        public async Task SubmitPrices()
        {
            await _workerInfoService.SubmitPrices();
        }

        public object? GetPagedWorkersInforamation(DataTablesAjaxRequestModel model)
		{
            
            var data = _workerInfoService.GetWorkersInformation(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "BarCodeData","Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                            select new string[]
                            {
                                    record.BarCodeData.ToString(),
                                    record.Id.ToString(),
                            }
                        ).ToArray()
            };
        }

        public object? GetPriceNotInsertedWorkersInformation(DataTablesAjaxRequestModel model)
        {
            var data = _workerInfoService.GetPriceNotInsertedWorkersInformation(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "BarCodeData", "Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.BarCodeData.ToString(),
                                record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public object? GetPagedWorkersPriceInforamation(DataTablesAjaxRequestModel model)
        {

            var data = _workerInfoService.GetWorkersPriceInformation(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "BarCodeData", "Id","Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                    record.BarCodeData.ToString(),
                                    record.Roll.ToString(),
                                    record.Price.ToString()
                        }
                        ).ToArray()
            };
        }
    }
}