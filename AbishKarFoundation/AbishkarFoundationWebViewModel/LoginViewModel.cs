using System;
using System.ComponentModel.DataAnnotations;

namespace AbishkarFoundation.Web.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
