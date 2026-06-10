public class FilmLogic
{
    private FilmAccess _filmAccess = new FilmAccess();

    public FilmModel CreateFilm(
        string? naam,
        string? genre,
        int tijdsduur,
        int leeftijdsgrens,
        string acteurs,
        string? regiseur)
    {
        ValidateFilmInput(naam, genre, tijdsduur, leeftijdsgrens, acteurs, regiseur);

        return new FilmModel
        {
            Naam = naam!.Trim(),
            Genre = genre!.Trim(),
            Tijdsduur = tijdsduur.ToString(),
            Leeftijdsgrens = leeftijdsgrens,
            Acteurs = acteurs.Trim(),
            Regiseur = regiseur!.Trim()
        };
    }

    public void AddFilm(FilmModel film)
    {
        ValidateFilm(film);
        _filmAccess.Write(film);
    }

    public List<FilmModel> GetAllFilms()
    {
        return _filmAccess.GetAll();
    }

    public FilmModel? GetFilmById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Film ID must be higher than 0.");

        return _filmAccess.GetById(id);
    }

    public void UpdateFilm(FilmModel film)
    {
        if (film.Id <= 0)
            throw new ArgumentException("Film ID is required.");

        ValidateFilm(film);
        _filmAccess.Update(film);
    }

    public void DeleteFilm(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Film ID must be higher than 0.");

        FilmModel? film = _filmAccess.GetById(id);

        if (film == null)
            throw new Exception("Film not found.");

        _filmAccess.Delete(film);
    }

    private void ValidateFilm(FilmModel film)
    {
        ValidateFilmInput(
            film.Naam,
            film.Genre,
            int.Parse(film.Tijdsduur!),
            film.Leeftijdsgrens ?? 0,
            film.Acteurs ?? "",
            film.Regiseur
        );
    }

    private void ValidateFilmInput(
        string? naam,
        string? genre,
        int tijdsduur,
        int leeftijdsgrens,
        string? acteurs,
        string? regiseur)
    {
        if (string.IsNullOrWhiteSpace(naam))
            throw new ArgumentException("Film name is required.");

        if (string.IsNullOrWhiteSpace(genre))
            throw new ArgumentException("Genre is required.");

        if (tijdsduur <= 0)
            throw new ArgumentException("Duration must be higher than 0.");

        if (leeftijdsgrens < 0)
            throw new ArgumentException("Age restriction cannot be negative.");

        if (string.IsNullOrWhiteSpace(acteurs))
            throw new ArgumentException("At least one actor is required.");

        if (string.IsNullOrWhiteSpace(regiseur))
            throw new ArgumentException("Director is required.");
    }
}