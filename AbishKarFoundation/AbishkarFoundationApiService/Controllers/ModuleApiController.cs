using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbishkarFoundation.ApiService.RequestModel;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
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
            var response = new UsersModuleRespons() { ResponseStatus=ResponseStatus.Success};
            try
            {
                if(string.IsNullOrEmpty(request.UserId))
                {
                    throw new ApplicationException("Not a valid user");
                }
                var viewmodels = new List<TestSet>();
                var modules = ModuleService.GetTestSetBos(request.UserId);
                foreach (var item in modules)
                {
                    viewmodels.Add(item.MapObject<TestSet>());
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








    }
}