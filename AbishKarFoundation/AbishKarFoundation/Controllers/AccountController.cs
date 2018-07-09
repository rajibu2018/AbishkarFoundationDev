using AbishkarFoundation.ApiService.Controllers;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using AbishkarFoundation.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
                var signUpRequest = viewModel.MapObject<SignUpRequest>();
                signUpRequest.UserType = UserType.Student;
                var api = new AccountApiController(UserAccounService);                
                api.SignUp(signUpRequest);
                return RedirectToAction("Login");
            }
            return View(viewModel);
        }
    }
}