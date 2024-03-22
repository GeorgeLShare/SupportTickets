using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;
using SupportTickets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTickets.UnitTests
{

    //provide short feedback loops,
    //improve code quality and maintainability,
    //reduce bug density.


    public class TicketServiceTests
    {
        public TicketServiceTests()
        {
        }


        [Fact]
        public void AddTicket_ValidTicket_AddsToDatabase()
        {
            var ticketService = new Mock<ITicketService>();

            var ticketToAdd = new Ticket { Id = 1, Description = "Test Ticket", Assignee = "George", CreatedDate = DateTime.Now, Name = "Test" };

            ticketService.Object.Add(ticketToAdd);

            ticketService.Verify(x => x.Add(ticketToAdd), Times.Once);

        }

        [Fact]
        public void DeleteTicket_ValidTicket_DeleteFromDatabase()
        {
            var ticketService = new Mock<ITicketService>();

            // Arrange
            var ticketToDelete = new Ticket { Id = 1, Description = "Test Ticket", Assignee = "George", CreatedDate = DateTime.Now, Name = "Test" };

            // Act
            ticketService.Object.DeleteTicket(ticketToDelete.Id);

            // Assert
            ticketService.Verify(x => x.DeleteTicket(ticketToDelete.Id), Times.Once);
        }

    }
}
