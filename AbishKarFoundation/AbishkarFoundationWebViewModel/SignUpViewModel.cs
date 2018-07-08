using System.ComponentModel.DataAnnotations;

namespace AbishkarFoundation.Web.ViewModel
{
    public class SignUpViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
