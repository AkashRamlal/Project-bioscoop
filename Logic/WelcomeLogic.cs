public static class WelcomeLogic
{
    public static List<string> PreviewFilms(List<FilmModel> films)
    {
        Random rand = new();
        List<string> returnList = [];

        if (films.Count < 5)
        {
            foreach (var film in films)
            {
                returnList.Add(film.Naam);
            }
            return returnList;
        }

        for (int i = 5; i <= 0; i--)
        {
            string addFilm = films[i].Naam!;
            returnList.Add(addFilm);
        }

        return returnList;
    }
}