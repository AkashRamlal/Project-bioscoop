using System;
using System.Collections.Generic;

public class Movie
{

    
    public string Title { get; set; }

    public static List<Movie> Movies = new();

    public List<MovieShowing> Showings { get; set; }

    public Movie(string title, List<MovieShowing> showings)
    {
        Title = title;
        Showings = showings;

        Movies.Add(this);
    }

    public static  void RunAuditorium(Movie ChoosedMovie, MovieShowing ChoosedTime, AccountModel? acc)
    {
        
        string AuditoriumNumber = ChoosedTime.Auditorium;

        if (ChoosedTime.IsDinnerEvent)
        {
            bool shouldAskInfo = acc == null || (acc.Allergie == null && acc.Dieet == null && acc.Opmerkingen == null);

            if (shouldAskInfo)
            {
                string? allergies = Diet.AskForAllergies();
                string? diet = Diet.AskForDietaryPreferences();
                string? comments = Diet.AskForAdditionalComments();
                if (acc != null)
                {
                    EditAccountLogic.EditDiet(acc, allergies, diet, comments);
                }
            }
        }

        Auditorium BookAuditorium = new(AuditoriumNumber);
        TicketService ticketService = new();

        List<string> reservedSeats = ticketService.ReservedTickets(AuditoriumNumber, ChoosedTime.StartTime.ToString());
        
        BookAuditorium.SetReservedSeats(reservedSeats);

        var dict = BookAuditorium.StartSelection(ChoosedMovie.Title, ChoosedTime.StartTime.ToString("dddd dd MMMM - HH:mm"));

        if (ChoosedTime.IsDinnerEvent)
        {
            foreach (var innerDict in dict.Values)
            {
                foreach (var key in innerDict.Keys.ToList())
                {
                    innerDict[key] += 50;
                }
            }
        }
        
        if(dict!= null)
        {
            if (acc != null)
            {
                PaymentUI paymentUI = new PaymentUI(true);
                paymentUI.StartAsMember(ChoosedMovie.Title, ChoosedTime.StartTime.ToString("dddd dd MMMM - HH:mm"), dict, acc.Email);
            }
            else
            {
                PaymentUI paymentUI = new PaymentUI(false);
                paymentUI.StartAsMember(ChoosedMovie.Title, ChoosedTime.StartTime.ToString("dddd dd MMMM - HH:mm"), dict, null);
            }
        }
        
    }

    public static Movie ArrowOptions(List<Movie> info)
    {

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            PrintOptions( info, selectedIndex);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = info.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= info.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return info[selectedIndex];
    }

    public static MovieShowing ArrowOptions(List<MovieShowing> info)
    {

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            PrintOptions( info, selectedIndex);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = info.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= info.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return info[selectedIndex];
    }


    public static void  PrintOptions(List<Movie> info, int selectedIndex)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"> {info[i].Title}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {info[i].Title}");
            }
        }        
    }

    public static void PrintOptions(List<MovieShowing> info, int selectedIndex)
    {
        for (int i = 0; i < info.Count; i++)
        {
            // If it's a dinner event, add "Dinner Event" after the time
            string displayText = info[i].IsDinnerEvent
                ? $"{info[i].StartTime} - Dinner Event (+€50)"
                : $"{info[i].StartTime}";

            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"> {displayText}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {displayText}");
            }
        }
    }
}