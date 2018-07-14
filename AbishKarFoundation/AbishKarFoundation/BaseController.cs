using AbishkarFoundation.ApiService.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AbishkarFoundation.UI
{
    public class BaseController:Controller
    {
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
            //var alerts = TempData.ContainsKey(Alert.TempDataKey)
            //    ? (List<Alert>)TempData[Alert.TempDataKey]
            //    : new List<Alert>();
            //var alerts = new Alert()
            //{
            //    AlertStyle = alertStyle,
            //    Message = message,
            //    Dismissable = dismissable
            //};
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
    }
}
