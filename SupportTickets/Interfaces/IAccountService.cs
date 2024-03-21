using Microsoft.AspNetCore.Identity;
using SupportTickets.Models.Database;
using SupportTickets.Models.ViewModels;

namespace SupportTickets.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUser(RegistrationViewModel model, string role);

        Task<IdentityResult> SetUserRole(User user, string role); //Might be worth setting a default role

        Task<SignInResult> Login(LoginViewModel model);

        Task LogOut();

        Task<User> GetUserAsync(string userId);
    }
}
