using System;
using AbishkarFoundation.ApiService.RequestModel;
using AbishkarFoundation.ApiService.ResponseModel;
using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
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
        [Route("User/SignUp")]
        public SignUpResponse SignUp(SignUpRequest request)
        {
            var response = new SignUpResponse();

            try
            {
                var dtNow = DateTime.Now;
                var user = request.MapObject<User>();
                user.Active = true;
                user.CreatedDate = dtNow;
                UserAccounService.SignUp(user, request.Password);
                response.Message = "Signup process completed succesfully";
            }
            catch(ApplicationException ax)
            {
                response.ResponseStatus =ResponseStatus.Warning ;
                response.Message = ax.Message;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failur;
                response.Message = "Unable to complete the signup process";
            }
            return response;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var response = new LoginResponse();
            try
            {
                var user= UserAccounService.Login(request.UserName, request.Password);
                response = user.MapObject<LoginResponse>();
                response.ResponseStatus = ResponseStatus.Success;
            }
            catch (ApplicationException ax)
            {
                response.ResponseStatus = ResponseStatus.Warning;
                response.Message = ax.Message;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failur;
                response.Message = "Unable to complete the login process";
            }
            return response;
        }
    }
}