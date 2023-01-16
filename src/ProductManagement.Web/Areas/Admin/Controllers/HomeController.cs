using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Web.Areas.Admin.Models;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        //public async Task<IActionResult> Insert()
        //{
        //    return View();
        //}
        public JsonResult GetWorkerData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<WorkerListModel>();
            return Json(model.GetPagedWorkers(dataTableModel));
        }
    }
}
