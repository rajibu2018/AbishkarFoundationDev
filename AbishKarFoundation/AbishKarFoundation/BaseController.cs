using AbishkarFoundation.ApiService.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;


namespace AbishkarFoundation.UI
{
    public class BaseController:Controller        
    {
        public UserDetails userDetails { get; set; }
        //public BaseController()
        //{
        //    userDetails.Name = GetUserName();
        //    userDetails.Email = GetUserEmail();
        //    userDetails.Role = GetUserRole();
        //    userDetails.UserId = GetUserId();

        //}
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Warning, message, dismissable);
        }

        public void NotifyUser(ResponseStatus status,string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                switch (status)
                {
                    case ResponseStatus.Success:
                        Success(message, true);
                        break;
                    case ResponseStatus.Failur:
                        Danger(message, true);
                        break;
                    case ResponseStatus.Warning:
                        Warning(message, true);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Danger, message, dismissable);
        }

        private void AddAlert(AlertStyle alertStyle, string message, bool dismissable)
        {
            switch (alertStyle)
            {
                case AlertStyle.Success:
                    TempData["SuccessNotification"] = message;
                    break;
                case AlertStyle.Information:
                    TempData["InformationNotification"] = message;
                    break;
                case AlertStyle.Warning:
                    TempData["WarningNotification"] = message;
                    break;
                case AlertStyle.Danger:
                    TempData["ErrorNotification"] = message;
                    break;
                default:
                    break;
            }

            
        }
        public string GetUserId()
        {
          return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        public string GetUserEmail()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
        public string GetUserName()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
        }
        public string GetUserRole()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        }
    }

    public class UserDetails
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdministratorInjectorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            //var result = filterContext.Result as ViewResultBase;
            //if (result != null)
            //{
            //    // the action returned a strongly typed view and passed a model
            //    var model = result.ViewData.Model as UserDetails;
            //    if (model != null)
            //    {
            //        // the model derived from BaseViewModel
            //        var controller = filterContext.Controller as BaseController;
            //        if (controller != null)
            //        {
            //            // The controller that executed this action derived
            //            // from BaseController and posses the IsAdministrator property
            //            // which is used to set the view model property
            //            model = controller.userDetails;
            //        }
            //    }
            //}
        }
    }
}
