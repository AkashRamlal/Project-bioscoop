public class SeatEntry
{
    public string Hall { get; set; } = "";
    public string SeatNumber { get; set; } = "";
    public decimal OriginalPrice { get; set; }
    public decimal FinalPrice { get; set; }
    public string Discount { get; set; } = "none";
    public bool Cancelled { get; set; } = false;
}