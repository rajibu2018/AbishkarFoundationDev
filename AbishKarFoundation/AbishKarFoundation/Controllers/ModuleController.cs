using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbishkarFoundation.ApiService.Controllers;
using AbishkarFoundation.ApiService.RequestModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Web.ViewModel.Module;
using Microsoft.AspNetCore.Mvc;

namespace AbishkarFoundation.UI.Controllers
{
    public class ModuleController : BaseController
    {
        public IModuleService ModuleService { get; set; }
        public ModuleApiController ModuleApiController;
        public ModuleController(IModuleService moduleService)
        {
            ModuleService = moduleService;
            ModuleApiController = new ModuleApiController(moduleService);
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }
            var request = new UsersModuleRequest { UserId = userId };
            var viewmodel = ModuleApiController.GetTeachersModules(request);
            if (viewmodel.TesSetViewModel == null)
            {
                viewmodel.TesSetViewModel = new TestSetViewModel();
            }
            return View(viewmodel.TesSetViewModel);
        }

        [Route("AddModule")]
        [Route("EditModule")]
        public ActionResult AddModule(int? id)
        {
            return View();
        }
    }
}