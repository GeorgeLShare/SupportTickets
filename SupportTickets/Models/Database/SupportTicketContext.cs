using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SupportTickets.Models.Database
{
    public class SupportTicketContext : IdentityDbContext<User>
    {
        public SupportTicketContext(DbContextOptions<SupportTicketContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
