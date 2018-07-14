using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbishkarFoundation.UI
{
    
    public class Alert
    {
       // public const string TempDataKey = "TempDataAlerts";

        public AlertStyle AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
    }

    //public static class AlertStyles
    //{
    //    public const string Success = "success";
    //    public const string Information = "info";
    //    public const string Warning = "warning";
    //    public const string Danger = "danger";
    //    //public static string[] ALL
    //    //{
    //    //    get { return new[] { Success, Warning, Information, Danger }; }
    //    //}
    //}
    public enum AlertStyle
    {
        Success,
        Information,
        Warning,
        Danger
    }
}
