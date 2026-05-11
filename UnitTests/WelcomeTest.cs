namespace UnitTests;

[TestClass]
public sealed class WelcomeTest
{
    [TestMethod]
    public void PreviewFilmsReturnsAllFilms()
    {
        FilmLogic filmLogic = new();
        List<FilmModel> films = [
            filmLogic.CreateFilm("Film 1", "Film 1", 1, 1, "Film 1", "Film 1"),
            filmLogic.CreateFilm("Film 2", "Film 2", 2, 2, "Film 2", "Film 2"),
            filmLogic.CreateFilm("Film 3", "Film 3", 3, 3, "Film 3", "Film 3")
        ];

        var result = WelcomeLogic.PreviewFilms(films);

        Assert.AreEqual(3, result.Count);
        CollectionAssert.Contains(result, "Film 1");
        CollectionAssert.Contains(result, "Film 2");
        CollectionAssert.Contains(result, "Film 3");
    }

    [TestMethod]
    public void PreviewFilmsReturnsFiveFilms()
    {
        FilmLogic filmLogic = new();
        List<FilmModel> films = [
            filmLogic.CreateFilm("Film 1", "Film 1", 1, 1, "Film 1", "Film 1"),
            filmLogic.CreateFilm("Film 2", "Film 2", 2, 2, "Film 2", "Film 2"),
            filmLogic.CreateFilm("Film 3", "Film 3", 3, 3, "Film 3", "Film 3"),
            filmLogic.CreateFilm("Film 4", "Film 4", 4, 4, "Film 4", "Film 4"),
            filmLogic.CreateFilm("Film 5", "Film 5", 5, 5, "Film 5", "Film 5"),
            filmLogic.CreateFilm("Film 6", "Film 6", 6, 6, "Film 6", "Film 6")
        ];

        var result = WelcomeLogic.PreviewFilms(films);

        Assert.AreEqual(5, result.Count);
    }
}