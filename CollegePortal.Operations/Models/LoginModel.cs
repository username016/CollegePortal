using System.ComponentModel.DataAnnotations;

namespace CollegePortal.Operation.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress] // Ensures the input is a valid email address
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // Ensures password input masking
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
