public class FilterSearch
{
    public bool HasTitle(FilmModel film, string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return true;

        return film.Naam.Contains(title, StringComparison.OrdinalIgnoreCase);
    }

    public bool HasGenre(FilmModel film, string genre)
    {
        return film.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase);
    }

    public bool HasActor(FilmModel film, string actor)
    {
        if (string.IsNullOrWhiteSpace(actor)) return true;

        if (string.IsNullOrWhiteSpace(film.Acteurs)) return false;

        return film.Acteurs
            .Split(';')
            .Any(a => a.Trim().Contains(actor, StringComparison.OrdinalIgnoreCase));
    }

    public bool HasDirector(FilmModel film, string director)
    {
        return film.Regiseur.Contains(director, StringComparison.OrdinalIgnoreCase);
    }

    public bool HasAgeRestriction(FilmModel film, int ageRestriction)
    {
        return film.Leeftijdsgrens == ageRestriction;
    }

    public List<FilmModel> FilterByTitle(List<FilmModel> films, string title)
    {
        return films.Where(film => HasTitle(film, title)).ToList();
    }

    public List<FilmModel> FilterByGenre(List<FilmModel> films, string genre)
    {
        return films.Where(film => HasGenre(film, genre)).ToList();
    }

    public List<FilmModel> FilterByActor(List<FilmModel> films, string actor)
    {
        return films.Where(film => HasActor(film, actor)).ToList();
    }

    public List<FilmModel> FilterByDirector(List<FilmModel> films, string director)
    {
        return films.Where(film => HasDirector(film, director)).ToList();
    }

    public List<FilmModel> FilterByAgeRestriction(List<FilmModel> films, int ageRestriction)
    {
        return films.Where(film => HasAgeRestriction(film, ageRestriction)).ToList();
    }
}