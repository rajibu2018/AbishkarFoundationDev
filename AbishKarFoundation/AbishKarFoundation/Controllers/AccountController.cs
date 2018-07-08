using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbishkarFoundation.ApiService.Controllers;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Repository;
using AbishkarFoundation.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AbishkarFoundation.UI.Controllers
{
    public class AccountController : Controller
    {
      

       
        public IUserAccountService UserAccounService { get; set; }
        public AccountController(IUserAccountService userAccountService)
        {
            UserAccounService = userAccountService;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Signup(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var signUpRequest = new SignUpRequest()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    UserName = viewModel.UserName,
                    Password = viewModel.Password,
                    ConfirmPassword = viewModel.ConfirmPassword
                };

                var api = new AccountApiController(UserAccounService);
                api.SignUp(signUpRequest);
                return Login();
            }
            return View(viewModel);
        }
    }
}