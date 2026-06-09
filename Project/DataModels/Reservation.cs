using System.Collections.Generic;

public class Reservation
{
    public string AuditoriumNumber { get; set; }
    public Dictionary<string, decimal> Seats { get; set; } = new();
}