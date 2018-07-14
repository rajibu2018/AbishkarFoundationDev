using System;
using AbishkarFoundation.ApiService.Controllers;
using AbishkarFoundation.ApiService.RequestModel;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using AbishkarFoundation.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AbishkarFoundation.UI.Controllers
{
    public class AccountController : BaseController
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
                var signUpRequest = viewModel.MapObject<SignUpRequest>();
                signUpRequest.UserType = UserType.Student;
                var api = new AccountApiController(UserAccounService);
                var response = api.SignUp(signUpRequest);
                NotifyUser(response.ResponseStatus, response.Message);
                if (response.ResponseStatus == ResponseStatus.Success)
                {
                    return RedirectToAction("Login");
                }

            }
            return View(viewModel);
        }       
    }
}