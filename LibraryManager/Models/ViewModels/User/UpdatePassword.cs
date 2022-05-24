using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models.ViewModels.User
{
    public class UpdatePassword
    {
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string OldPassword { get; set; }
    }
}
