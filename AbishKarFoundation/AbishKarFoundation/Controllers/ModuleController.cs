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
            var response = ModuleApiController.GetTeachersModules(request);
            NotifyUser(response.ResponseStatus, response.Message);
            if (response.TesSetViewModel == null)
            {
                response.TesSetViewModel = new TestSetViewModel();
            }
            return View(response.TesSetViewModel);
        }

        [Route("AddModule")]
        [Route("EditModule")]
        public ActionResult AddModule(int? id)
        {
            var viewModel = new TestSetCreateViewModel();
            if (id!=null)
            {
                var request = new GetTestSetRequest() { TestSetId = id.Value };
                viewModel = ModuleApiController.GetTestSet(request).TestSetCreateViewModel;
                viewModel.ViewName = "Edit Module";
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SaveModule(TestSetCreateViewModel viewModel)
        {
            var request = new SaveTestSetRequest();

            if(viewModel.TestSetId==0)
            {
                viewModel.CreateDate = DateTime.Now;
                viewModel.CreatorId = Convert.ToInt32(GetUserId());                
                viewModel.Active = true;
                //test line
            }
            else
            {
                if (viewModel.CreatorId != Convert.ToInt32(GetUserId()))
                    NotifyUser(ApiService.ResponseModel.ResponseStatus.Warning, "You are not authorize to edit this module");
                
            }
            request.TestSetCreateViewModel = viewModel;
            
            var response= ModuleApiController.SaveTestSetResponse(request);
            viewModel = response.TestSetCreateViewModel;
            viewModel.ViewName = "Edit Module";
            NotifyUser(response.ResponseStatus, response.Message);
            return View("AddModule", viewModel);
        }
    }
}