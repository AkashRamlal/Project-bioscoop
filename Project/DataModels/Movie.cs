public class Movie
{
    public string Title { get; set; }

    public List<MovieShowing> Showings { get; set; }

    public Movie(string title, List<MovieShowing> showings)
    {
        Title = title;
        Showings = showings;
    }
}