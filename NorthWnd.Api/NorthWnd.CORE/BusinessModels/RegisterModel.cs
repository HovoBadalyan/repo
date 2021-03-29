using System.ComponentModel.DataAnnotations;

namespace NorthWnd.CORE.BusinessModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        
        public string Password { get; set; }

        
        [Compare("Password", ErrorMessage = " Password is incorrect")]
        public string ConfirmPassword { get; set; }
    }
}
