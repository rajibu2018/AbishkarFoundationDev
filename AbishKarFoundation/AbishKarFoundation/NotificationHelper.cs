using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbishkarFoundation.UI
{
    
    public class Alert
    {
        public AlertStyle AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
    }  
    public enum AlertStyle
    {
        Success,
        Information,
        Warning,
        Danger
    }
}
