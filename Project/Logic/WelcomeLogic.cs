public static class WelcomeLogic
{
    public static List<string> PreviewFilms(List<FilmModel> films)
    {
        Random rand = new();
        List<string> returnList = [];
        List<FilmModel> filmsCopy = new List<FilmModel>(films);

        if (filmsCopy.Count < 5)
        {
            foreach (var film in filmsCopy)
            {
                returnList.Add(film.Naam);
            }
            return returnList;
        }

        for (int i = 0; i < 5; i++)
        {
            int index = rand.Next(filmsCopy.Count);
            string addFilm = filmsCopy[index].Naam!;
            returnList.Add(addFilm);
            filmsCopy.RemoveAt(index);
        }

        return returnList;
    }
}