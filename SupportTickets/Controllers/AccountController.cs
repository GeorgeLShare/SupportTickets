using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;
using SupportTickets.Models.ViewModels;

namespace SupportTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<User> userManager,
                                 ILogger<AccountController> logger,
                                 IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [Authorize]// User had to be logged in to view this page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Edit")]// User has to be loged in to view this page
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            //Make it so only admins can register accounts
            if (ModelState.IsValid)
            {
                var registerUser = await _accountService.RegisterUser(model, "Restricted");

                if (registerUser.Succeeded)
                {
                    _logger.LogInformation("User Registered");
                    return RedirectToAction("Tickets", "Ticket");
                }
                else
                {
                    foreach (var error in registerUser.Errors)
                    {
                        ModelState.TryAddModelError("", error.Description);
                    }
                }
            }
            return View(); //pick up all the mistakes in the viewmodel and display validation messages

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginUser = await _accountService.Login(model);
                if (loginUser.Succeeded)
                {
                    //redirects to page since you are authorised to login
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].FirstOrDefault()); // This is the standard query string that gets passed normally
                    }
                    else
                    {
                        return RedirectToAction("Tickets", "Ticket");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Failed to Login");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated) // Check if the user is logged in
            {
                await _accountService.LogOut();
            }
            return RedirectToAction("Login", "Account"); //Once logged out makes sense to send user to a home page

        }
    }
}
