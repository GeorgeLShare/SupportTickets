using SupportTickets.Interfaces;
using SupportTickets.Models.Database;

namespace SupportTickets.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(SupportTicketContext context) : base(context)
        {
                
        }
    }
}
