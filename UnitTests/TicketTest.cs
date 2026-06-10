namespace UnitTests;

[TestClass]
public class TicketTests
{
    [TestMethod]

    private static void TicketService_CreateTickets_ReturnsCreatedTickets()
    {
        // Arrange
        TicketService service = new TicketService();
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

}
