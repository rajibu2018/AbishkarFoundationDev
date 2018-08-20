using AbishkarFoundation.ApiService.Controllers;
using AbishkarFoundation.ApiService.RequestModel;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using AbishkarFoundation.Web.ViewModel.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace AbishkarFoundation.UI.Controllers
{
    public class AccountController : BaseController
    {
        public IUserAccountService UserAccounService { get; set; }
        public AccountApiController AccountApiController;
        public AccountController(IUserAccountService userAccountService)
        {
            UserAccounService = userAccountService;
            AccountApiController = new AccountApiController(UserAccounService);
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
            //test
            if (ModelState.IsValid)
            {
                var signUpRequest = viewModel.MapObject<SignUpRequest>();
                signUpRequest.UserType = UserType.Teacher;
                //var api = new AccountApiController(UserAccounService);
                var response = AccountApiController.SignUp(signUpRequest);
                NotifyUser(response.ResponseStatus, response.Message);
                if (response.ResponseStatus == ResponseStatus.Success)
                {
                    return RedirectToAction("Login");
                }

            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = viewModel.MapObject<LoginRequest>();
                var response = AccountApiController.Login(loginRequest);
                NotifyUser(response.ResponseStatus, response.Message);
                var logginUserDetails = new Dictionary<string, string>();
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, response.UserId.ToString())
                    };
                claims.Add(new Claim(ClaimTypes.Role, response.UserType.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, response.Email.ToString()));
                claims.Add(new Claim(ClaimTypes.Sid, response.UserName.ToString()));

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);
                if (response.UserType == UserType.Teacher)
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else if(response.UserType==UserType.Student)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
            return RedirectToAction("Login", viewModel);
        }
      
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}