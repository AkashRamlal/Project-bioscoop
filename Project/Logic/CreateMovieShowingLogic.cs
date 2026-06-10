public static class CreateMovieShowingLogic
{
    public static MovieShowingsAccess movieShowingsAccess = new MovieShowingsAccess();
    public static FilmAccess filmAccess = new FilmAccess();
    public static bool AddMovieShowing(FilmModel selectedFilm, DateTime startTime, string auditorium, bool isDinnerEvent)
    {
        MovieShowing showing = new MovieShowing
            {
                FilmId = selectedFilm.Id,
                StartTime = startTime,
                Auditorium = auditorium,
                IsDinnerEvent = isDinnerEvent
            };

            if (HasOverlappingTime(showing, selectedFilm))
                return false;
            
            movieShowingsAccess.Write(showing);
            return true;
    }

    public static bool HasOverlappingTime(MovieShowing newShowing, FilmModel selectedFilm)
    {
        List<MovieShowing> allShowings = movieShowingsAccess.GetAll();
        List<FilmModel> allFilms = filmAccess.GetAll();

        DateTime newStartTime = newShowing.StartTime;
        DateTime newEndTime = newShowing.StartTime.AddMinutes(Convert.ToDouble(selectedFilm.Tijdsduur));

        foreach (var showing in allShowings)
        {
            FilmModel existingFilm = allFilms.First(f => f.Id == showing.FilmId);
            DateTime existingStartTime = showing.StartTime;
            DateTime existingEndTime = showing.StartTime.AddMinutes(Convert.ToDouble(existingFilm.Tijdsduur));

            if (newStartTime < existingEndTime && newEndTime > existingStartTime)
            {
                return true;
            }
        }
        return false;
    }
}