using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
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
            var user = new User()
            {
                FirstName=request.FirstName,
                LastName=request.LastName,
                Active=true,
                CreatedDate= dtNow,
                Email=request.Email,
                UserName=request.UserName,
                Password=request.Password,
                UserType=UserType.Student,
                
            };
            UserAccounService.SignUp(user);
            return new SignUpResponse();
        }
    }
}