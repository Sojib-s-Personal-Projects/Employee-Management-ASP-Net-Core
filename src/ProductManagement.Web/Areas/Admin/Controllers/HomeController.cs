using Autofac;
using Infrastructure.BusinessObjects;
using Infrastructure.Enum;
using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Web.Areas.Admin.Models;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Price()
        {
            return View();
        }

        public async Task<IActionResult> Report()
        {
            var model = _scope.Resolve<ReportModel>();
            IList<Worker> workerList= await model.GetWorkersList();

            return View(workerList);
        }

        public async Task<IActionResult> DashBoard()
        {
            var model = _scope.Resolve<DashBoardModel>();
            await model.GetPriceNotInsertedWorkersCount();
            await model.GetUnscannedWorkersCount();

            return View(model);
        }


        public async Task<IActionResult> UpdateDetails(long id)
        {
            var model = _scope.Resolve<WorkerInfoModel>();
            await model.StoreRoll(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDetails(WorkerInfoModel model)
        {
            try
            {
                model.ResolveDependency(_scope);
                bool sameBarCode = await model.CheckForSameBarcode();
                if (!sameBarCode)
                {
                    throw new ValueNotMatchingException("The Bar Codes Don't Match");
                }

                await model.InserData();

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Successfully Inserted Data.",
                    Type = ResponseTypes.Success
                });

                return View(model);
            }
            catch (ValueNotMatchingException ioe)
            {
                _logger.LogError(ioe, ioe.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = ioe.Message,
                    Type = ResponseTypes.Danger
                });
            }
            catch (WorkerExistsException ioe)
            {
                _logger.LogError(ioe, ioe.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = ioe.Message,
                    Type = ResponseTypes.Danger
                });
            }
            catch (BarCodeExistsException ioe)
            {
                _logger.LogError(ioe, ioe.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = ioe.Message,
                    Type = ResponseTypes.Danger
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "There was a problem in updating details.",
                    Type = ResponseTypes.Danger
                });
            }

            return View(model);
        }

        public async Task<IActionResult> InsertPrice(string id)
        {
            var model = _scope.Resolve<WorkerInfoModel>();

            await model.LoadData(id);

            return View(model);
        }

        public async Task<IActionResult> InsertPriceList()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertPrice(WorkerInfoModel model)
        {
            try
            {
                model.ResolveDependency(_scope);

                model.InserPrice();

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Successfully Inserted Price.",
                    Type = ResponseTypes.Success
                });

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "There was a problem in inserting price.",
                    Type = ResponseTypes.Danger
                });
            }

            return View(model);
        }

        public async Task<JsonResult> GetWorkerData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<WorkerListModel>();
            return Json(model.GetPagedWorkers(dataTableModel));
        }

        public async Task<JsonResult> GetWorkersInformationData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<WorkerInfoListModel>();
            return Json(model.GetPagedWorkersInforamation(dataTableModel));
        }

        public async Task<JsonResult> GetPriceNotInsertedWorkersInformation()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<WorkerInfoListModel>();
            return Json(model.GetPriceNotInsertedWorkersInformation(dataTableModel));
        }
    }
}