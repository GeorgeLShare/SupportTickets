using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SupportTickets.Models.Database
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
