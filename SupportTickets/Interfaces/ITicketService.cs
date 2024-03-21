using SupportTickets.Models.Database;

namespace SupportTickets.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetTicketsAsync(string userId);

        void Add(Ticket ticket);

        Ticket Get(int id);

        void Update(Ticket ticket);

        Ticket GetWithTicketId(int ticketId);

        Task<List<Ticket>> GetTicketsAsync();

        void DeleteTicket(int ticketId);
    }
}
