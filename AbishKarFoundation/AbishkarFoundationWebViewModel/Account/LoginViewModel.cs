using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbishkarFoundation.Web.ViewModel.Account
{
   public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name / Email")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
