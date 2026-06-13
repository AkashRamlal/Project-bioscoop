namespace UnitTests;

[TestClass]
public sealed class TestCreateMovieShowing
{
    [TestMethod]
    public void HasOverlappingTime_ReturnsFalse_WhenNoOverlapExists()
    {
        FilmModel film = new FilmModel
        {
            Id = 1,
            Tijdsduur = "120"
        };

        MovieShowing showing = new MovieShowing
        {
            FilmId = 1,
            StartTime = new DateTime(2030, 1, 1, 10, 0, 0),
            Auditorium = "Auditorium 1"
        };

        bool result =
            CreateMovieShowingLogic.HasOverlappingTime(showing, film);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void MovieShowing_EndTime_IsCalculatedCorrectly()
    {
        FilmModel film = new FilmModel
        {
            Id = 1,
            Tijdsduur = "120"
        };

        DateTime startTime = new DateTime(2030, 1, 1, 10, 0, 0);

        DateTime endTime =
            startTime.AddMinutes(Convert.ToDouble(film.Tijdsduur));

        Assert.AreEqual(
            new DateTime(2030, 1, 1, 12, 0, 0),
            endTime);
    }

    [TestMethod]
    public void MovieShowing_CanBeCreated()
    {
        FilmModel film = new FilmModel
        {
            Id = 1,
            Tijdsduur = "120"
        };

        bool result =
            CreateMovieShowingLogic.AddMovieShowing(
                film,
                new DateTime(2030, 1, 1, 10, 0, 0),
                "Auditorium 1",
                false);

        Assert.IsTrue(result);
    }
}