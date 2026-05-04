public class FilmModel
{
    public Int64 Id { get; set; }
    public string? Naam { get; set; }
    public string? Genre { get; set; }
    public string? Tijdsduur { get; set; } // in minutes
    public int? Leeftijdsgrens { get; set; }
}   