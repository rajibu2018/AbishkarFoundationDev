using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbishkarFoundation.ApiService.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountApi")]
    public class AccountApiController : Controller
    {
        private IUserAccountService UserAccounService { get; set; }
        public AccountApiController(IUserAccountService userAccountService)
        {
            UserAccounService = userAccountService;
        }

        [HttpPost]
        public SignUpResponse SignUp(SignUpRequest request)
        {
            var dtNow = DateTime.Now;
            var user = request.MapObject<User>();
            user.Active = true;
            user.CreatedDate = dtNow;
            UserAccounService.SignUp(user);
            return new SignUpResponse();
        }
    }
}