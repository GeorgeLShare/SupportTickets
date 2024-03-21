using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;
using SupportTickets.Services;

namespace SupportTickets.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<User> _userManager;
        private readonly IAccountService _accountService;

        public TicketController(ITicketService ticketService,
            UserManager<User> userManager,
            IAccountService accountService)
        {
            _ticketService = ticketService;
            _userManager = userManager;
            _accountService = accountService;
        }


        [HttpGet]
        public async Task<IActionResult> Tickets()
        {
            if (User.Identity.IsAuthenticated)
            {
                var tickets = await _ticketService.GetTicketsAsync();

                return View(tickets);//Displays the tickets View
            }

            return RedirectToAction("Login", "Account"); //Redirect the unauthenticated user to login if they try to view tickets
        }

        //Get Create Ticket Form
        [Authorize(Roles = "Edit")] //Only users with Edit role can modify
        [HttpGet]
        public IActionResult CreateTicketForm()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Account", "Login"); //Redirect the user to login if they try to create views
        }

        //Create Quiz
        [Authorize(Roles = "Edit")]
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                var user = await _accountService.GetUserAsync(userId);

                ticket.User = user;

                ticket.CreatedDate = DateTime.UtcNow;

                _ticketService.Add(ticket);

                return RedirectToAction("Tickets");// Once added display Tickets View
            }

            return View();
        }

        [Authorize(Roles = "Edit")]
        [HttpGet]
        public IActionResult UpdateTicket(int Id)
        {
            //Pass in the ticketId
            var UpdateTicket = _ticketService.Get(Id);

            return View(UpdateTicket);
        }

        [Authorize(Roles = "Edit")]
        [HttpPost]
        public IActionResult UpdateTicket(Ticket ticket)
        {

            if (!ModelState.IsValid)
            {
                return View(ticket);
            }
            _ticketService.Update(ticket);

            return RedirectToAction("Tickets");
        }

        [Authorize(Roles = "Edit")]
        [HttpGet]
        public IActionResult DeleteTicket(int Id)//Pass in TicketId
        {
            _ticketService.DeleteTicket(Id);

            return RedirectToAction("Tickets");
        }

        [HttpGet]
        public IActionResult ViewTicket(int Id)
        {
            //Pass in the ticketId
            var ViewTicket = _ticketService.Get(Id);

            return View(ViewTicket);
        }
    }
}
