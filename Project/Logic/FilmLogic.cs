public class FilmLogic
{
    public FilmModel CreateFilm(
        string? naam,
        string? genre,
        int tijdsduur,
        int leeftijdsgrens,
        string acteurs,
        string? regiseur)
    {
        return new FilmModel
        {
            Naam = naam,
            Genre = genre,
            Tijdsduur = tijdsduur.ToString(), 
            Leeftijdsgrens = leeftijdsgrens,
            Acteurs = acteurs,
            Regiseur = regiseur
        };
    }
}