using Microsoft.EntityFrameworkCore;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;

namespace SupportTickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void Add(Ticket ticket)
        {
            _ticketRepository.Create(ticket);
        }

        public void DeleteTicket(int ticketId)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            _ticketRepository.Delete(ticket);
        }

        public Ticket Get(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public List<Ticket> GetTicketsAsync(string userId)
        {
            return _ticketRepository.FindWithId(x => x.User?.Id == userId).ToList();
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _ticketRepository.GetAll().ToListAsync();
        }

        public Ticket GetWithTicketId(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }
    }
}
