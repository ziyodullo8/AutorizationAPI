using System.ComponentModel.DataAnnotations;

namespace AutorizationAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PassWord is required")]
        public string PassWord { get; set; }
    }
}
