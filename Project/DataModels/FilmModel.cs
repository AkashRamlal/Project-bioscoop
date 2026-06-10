public class FilmModel
{
    public int Id { get; set; }
    public string? Naam { get; set; }
    public string? Genre { get; set; }
    public string? Tijdsduur { get; set; } // in minutes
    public int? Leeftijdsgrens { get; set; }

    public string? Acteurs { get; set; }

    public string? Regiseur { get; set; }
}   