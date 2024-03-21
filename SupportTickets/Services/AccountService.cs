using Microsoft.AspNetCore.Identity;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;
using SupportTickets.Models.ViewModels;

namespace SupportTickets.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountService> _logger;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager,
               ILogger<AccountService> logger,
               SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegistrationViewModel model, string role)
        {
            //get the values from registration view model
            var user = new User
            {
                UserName = model.UserName,
                NormalizedUserName = model.UserName.ToUpper(),
                Email = model.UserName,
                NormalizedEmail = model.UserName.ToUpper(),
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            //Create a user using the user manager
            var result = await _userManager.CreateAsync(user, model.Password);

            await SetUserRole(user, role);

            return result;
        }

        //Can use this in the future to add other roles to accounts
        public async Task<IdentityResult> SetUserRole(User user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }

        public async Task<SignInResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> GetUserAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
