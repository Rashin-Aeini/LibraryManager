using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models.ViewModels.Auth
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
