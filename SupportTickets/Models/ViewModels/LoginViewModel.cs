using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SupportTickets.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
