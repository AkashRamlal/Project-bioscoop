namespace UnitTests;

[TestClass]
public class FilmLogicTests
{
    [TestMethod]
    public void CreateFilm_WithValidInput_ShouldReturnFilmModel()
    {
        FilmLogic logic = new FilmLogic();

        FilmModel film = logic.CreateFilm(
            "Inception",
            "Sci-Fi",
            148,
            12,
            "Leonardo DiCaprio, Tom Hardy",
            "Christopher Nolan"
        );

        Assert.AreEqual("Inception", film.Naam);
        Assert.AreEqual("Sci-Fi", film.Genre);
        Assert.AreEqual("148", film.Tijdsduur);
        Assert.AreEqual(12, film.Leeftijdsgrens);
        Assert.AreEqual("Leonardo DiCaprio, Tom Hardy", film.Acteurs);
        Assert.AreEqual("Christopher Nolan", film.Regiseur);
    }


    [TestMethod]
    public void CreateFilm_WithEmptyName_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "",
                "Action",
                120,
                16,
                "Actor One",
                "Director One"
            );
        });
    }


    [TestMethod]
    public void CreateFilm_WithEmptyGenre_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "Movie",
                "",
                120,
                16,
                "Actor One",
                "Director One"
            );
        });
    }


    [TestMethod]
    public void CreateFilm_WithZeroDuration_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "Movie",
                "Action",
                0,
                16,
                "Actor One",
                "Director One"
            );
        });
    }


    [TestMethod]
    public void CreateFilm_WithNegativeDuration_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "Movie",
                "Action",
                -10,
                16,
                "Actor One",
                "Director One"
            );
        });
    }


    [TestMethod]
    public void CreateFilm_WithNegativeAgeRestriction_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "Movie",
                "Action",
                120,
                -1,
                "Actor One",
                "Director One"
            );
        });
    }


    [TestMethod]
    public void CreateFilm_WithEmptyActors_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "Movie",
                "Action",
                120,
                16,
                "",
                "Director One"
            );
        });
    }


    [TestMethod]
    public void CreateFilm_WithEmptyDirector_ShouldThrowException()
    {
        FilmLogic logic = new FilmLogic();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            logic.CreateFilm(
                "Movie",
                "Action",
                120,
                16,
                "Actor One",
                ""
            );
        });
    }
}