using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbishkarFoundation.ApiService.RequestModel;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using AbishkarFoundation.Web.ViewModel.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbishkarFoundation.ApiService.Controllers
{
    [Produces("application/json")]
    [Route("api/ModuleApi")]
    public class ModuleApiController : Controller
    {
        public IModuleService ModuleService { get; set; }
        public ModuleApiController(IModuleService moduleService)
        {
            ModuleService = moduleService;
        }

        [HttpGet]
        [Route("User/teacher/Module")]
        public UsersModuleRespons GetTeachersModules(UsersModuleRequest request)
        {
            var response = new UsersModuleRespons() { ResponseStatus = ResponseStatus.Success };
            try
            {
                if (string.IsNullOrEmpty(request.UserId))
                {
                    throw new ApplicationException("Not a valid user");
                }
                var viewmodels = new List<TestSetModel>();
                var modules = ModuleService.GetTestSetBos(request.UserId);
                foreach (var item in modules)
                {
                    var vm = item.MapObject<TestSetModel>();
                    vm.CreatorId = Convert.ToInt32(request.UserId);
                    viewmodels.Add(vm);

                }
                response.TesSetViewModel.TestSets = viewmodels;
            }
            catch (ApplicationException ax)
            {
                response.ResponseStatus = ResponseStatus.Warning;
                response.Message = ax.Message;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failur;
                response.Message = "Unable to fetch user's modules";
            }
            return response;
        }

        [HttpPost]
        [Route("User/Module/Save")]
        public SaveTestSetResponse SaveTestSetResponse(SaveTestSetRequest request)
        {
            var response = new SaveTestSetResponse { ResponseStatus = ResponseStatus.Success };
            if (string.IsNullOrEmpty(request.TestSetCreateViewModel.TestName))
            {
                throw new ApplicationException("Test name is required");
            }
            try
            {
                var testSet = request.TestSetCreateViewModel.MapObject<TestSet>();
                testSet = ModuleService.SaveTestSet(testSet, request.TestSetCreateViewModel.CreatorId);
                var responseModel = testSet.MapObject<TestSetCreateViewModel>();
                response.TestSetCreateViewModel = responseModel;
            }
            catch (ApplicationException ax)
            {
                response.ResponseStatus = ResponseStatus.Warning;
                response.Message = ax.Message;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failur;
                response.Message = "Unable to save module";
            }
            return response;
        }
        [HttpGet]
        [Route("User/get/TestSet")]
        public GetTesSetResponse GetTestSet(GetTestSetRequest request)
        {
            var response = new GetTesSetResponse { ResponseStatus = ResponseStatus.Success };
            if(request.TestSetId<0)
            {
                throw new ApplicationException("Not a valid module");
            }
            try
            {
                var testSet= ModuleService.GetTestSet(request.TestSetId);
                var responseModel = testSet.MapObject<TestSetCreateViewModel>();
                responseModel.CreatorId = testSet.Creator.UserId;
                response.TestSetCreateViewModel = responseModel;
            }
            catch (ApplicationException ax)
            {
                response.ResponseStatus = ResponseStatus.Warning;
                response.Message = ax.Message;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failur;
                response.Message = "Unable to retrive module";
            }
            return response;
        }
    }
}