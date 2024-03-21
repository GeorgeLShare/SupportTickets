using System.ComponentModel.DataAnnotations;

namespace SupportTickets.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Display(Name = "User Name")]
        [Required, MaxLength(256)] // Check this in db
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
