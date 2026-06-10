namespace UnitTests;

[TestClass]
public class TicketTests
{
    TicketService service = new TicketService();
    [TestMethod]
    public void TicketService_CreateTickets_ReturnsCreatedTickets()
    {
        // Arrange
        string filmName = "Test Movie";
        DateTime time = DateTime.Now;
        Dictionary<string, Dictionary<string, decimal>> hallData = new()
        {
            { "Hall 1", new Dictionary<string, decimal> { { "A1", 10.00m }, { "A2", 10.00m } } }
        };
        string email = "test@example.com";
        // Act
        List<Ticket> createdTickets = service.CreateTickets(filmName, time, hallData, email);
        // Assert
        Assert.AreEqual(1, createdTickets.Count);
        Ticket ticket = createdTickets[0];
        Assert.AreEqual(filmName, ticket.FilmName);
        Assert.AreEqual(time, ticket.Date);
        Assert.AreEqual("Hall 1", ticket.Hall);
        Assert.AreEqual("A1 (€10.00), A2 (€10.00)", ticket.Seats);
        Assert.AreEqual(20.00m, ticket.TotalPrice);
        Assert.AreEqual(email, ticket.Email);
        Assert.AreEqual(hallData.Values.First(), ticket.HallData);
    }
    
    [TestMethod]
    public void TicketService_GetTicketsByEmail_ReturnsTicketsForEmail()
    {
        // Arrange
        string email = "test@example.com";
        // Act
        List<Ticket> tickets = service.GetTicketsByEmail(email);
        Ticket ticket = tickets[0];
        Assert.AreEqual(email, ticket.Email);
    }

    [TestMethod]
    public void TicketService_CancelTicket_ReturnsTrueIfCancellable()
    {
        // Arrange
        Ticket ticket = new Ticket
        {
            FilmName = "Test Movie",
            Hall = "Auditorium 1",
            Date = DateTime.Now.AddHours(3),
            Seats = "A1 (€10.00), A2 (€10.00)",
            TotalPrice = 20.00m,
            Email = "test@example.com"
        };
        // Act
        bool result = service.CancelTicket(ticket);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TicketService_CancelTicket_ReturnsFalseIfNotCancellable()
    {
        // Arrange
        Ticket ticket = new Ticket
        {
            FilmName = "Test Movie",
            Hall = "Auditorium 1",
            Date = DateTime.Now.AddHours(1), // Less than 2 hours away
            Seats = "A1 (€10.00), A2 (€10.00)",
            TotalPrice = 20.00m,
            Email = "test@example.com"
        };
        // Act
        bool result = service.CancelTicket(ticket);
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TicketService_ReservedTickets_ReturnsAllReservedTickets()
    {
        // Arrange
        string filmName = "Test Movie";
        DateTime date = DateTime.Now;
        string hall = "Hall 1";
        // Act
        List<string> reservedSeats = service.ReservedTickets(filmName, date, hall);
        // Assert
        Assert.IsNotNull(reservedSeats);
    }

    [TestMethod]
    public void TicketService_ChangeTicket_ReturnsTrueIfCancellable()
    {
        // Arrange
        Ticket ticket = new Ticket
        {
            FilmName = "Test Movie",
            Hall = "Auditorium 1",
            Date = DateTime.Now.AddHours(3),
            Seats = "A1 (€10.00), A2 (€10.00)",
            TotalPrice = 20.00m,
            Email = "test@example.com"
        };
        AccountModel acc = new AccountModel
        {
            Id = 1,
            Naam = "John",
            Achternaam = "Doe",
            Geboortedatum = new DateTime(1990, 1, 1),
            Telefoonnummer = "1234567890",
            Role = Roles.Member,
            Email = "test@example.com",
            Password = "password"   
        };  
        // Act
        bool result = service.ChangeTicket(ticket, acc);
        // Assert
        Assert.IsTrue(result);
    }
}
