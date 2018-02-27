using System.ComponentModel.DataAnnotations;

namespace PaddleHub.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}