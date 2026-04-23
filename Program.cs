using System;
using System.Collections.Generic;

static class Program
{

    static void Main()
    {

        new Movie("Lion Queen", new List<string> {"12:00 Auditorium 1", "15:00 Auditorium 2 ", "20:00 Auditorium 3"});
        new Movie("Lilo & Boots", new List<string> {"11:00 Auditorium 2", "14:00 Auditorium 3", "17:00 Auditorium 1"});
        new Movie("101 Monkeys", new List<string> {"13:00 Auditorium 2", "15:00 Auditorium 1", "19:00 Auditorium 2"});
        new Movie("The Conjurings", new List<string> {"22:00 Auditorium 3", "00:00 Auditorium 2", "18:00 Auditorium 1"});

        string gekozenTitel = Movie.ArrowOptions(Movie.Movies);
        List<string> beschikbareTijden = Movie.MoviesDict[gekozenTitel];
        string gekozenTijd = Movie.ArrowOptions(beschikbareTijden);

        Movie.RunAuditorium( gekozenTitel, gekozenTijd);
        
        

        


    }


    
}