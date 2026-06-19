using System;

public class AuditoriumConsoleView
{
    private readonly AuditoriumService _service;

    private int _cursorVertical = 4;
    private int _cursorHorizontal = 8;

    public AuditoriumConsoleView(AuditoriumService service)
    {
        _service = service;
    }

    public Reservation StartSelection(AuditoriumModel auditorium,string title,string time)
    {
        string showKey = $"{title}-{time}-{auditorium.Number}";
        Reservation reservation = new Reservation
        {
            AuditoriumNumber = auditorium.Number, Showkey = showKey
        };

        bool choosingSeat = true;

        while (choosingSeat)
        {
            Display(auditorium, title, time);

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter) // gebruiker heeft seat gekozen
            {
                try
                {
                    _service.BookSeat(
                        auditorium,
                        reservation,
                        _cursorVertical,
                        _cursorHorizontal
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

            }
            else if (key == ConsoleKey.Escape)
            {
                choosingSeat = false;
            }
            else
            {
                MoveCursor(auditorium, key);
            }
        }

        return reservation;
    }

    private void Display(AuditoriumModel auditorium, string title, string time)
    {
        Console.Clear();
        

        string shortTime = time.Split(" ")[0];

        Console.WriteLine($"Movie: {title}");
        Console.WriteLine($"Time: {shortTime}");

        SeatType[,] seats = auditorium.Seats;

        int AantalStoelenVerticaal = seats.GetLength(0);
        int AantalStoelenHorizontaal = seats.GetLength(1);

        Console.Write("   ");

        for (int i = 1; i <= AantalStoelenHorizontaal; i++)
        {
            Console.Write($" {i:D2}");
        }

        Console.WriteLine();

        for (int horizontal = 0; horizontal < AantalStoelenVerticaal; horizontal++)
        {
            Console.Write($"{AantalStoelenVerticaal - horizontal:D2} ");

            for (int verticaal = 0; verticaal < AantalStoelenHorizontaal; verticaal++)
            {
                if (seats[horizontal, verticaal] == SeatType.Empty)
                {
                    Console.Write("   ");
                    continue;
                }

                if (horizontal == _cursorVertical && verticaal == _cursorHorizontal) // start
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    ConsoleColor chosenColor;

                    switch (seats[horizontal, verticaal])
                    {
                        case SeatType.Basic:
                            chosenColor = ConsoleColor.Blue; // buitenste
                            break;

                        case SeatType.Comfort:
                            chosenColor = ConsoleColor.DarkYellow; // middelste
                            break;

                        case SeatType.Premium:
                            chosenColor = ConsoleColor.Red; // binnenste
                            break;

                        case SeatType.Reserved:
                            chosenColor = ConsoleColor.DarkGreen; // gereserveert
                            break;

                        default:
                            chosenColor = ConsoleColor.Black;
                            break;
                    }

                    Console.ForegroundColor = chosenColor;
                }

                Console.Write("[#]");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        if(auditorium.Number == "Auditorium 3")
        {
            Console.WriteLine("                                              SCREEN          ");
        }
        else if (auditorium.Number == "Auditorium 1")
        {
            Console.WriteLine("                SCREEN          ");
        }
        else if (auditorium.Number == "Auditorium 2")
        {
            Console.WriteLine("                          SCREEN          ");
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Blue = Basic (€11)   ");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Yellow = Comfort (€12)   ");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Red = Premium (€14)   ");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("Green = Reserved");

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        

        Console.WriteLine("Use arrow keys to navigate, press Enter to select option.");
        Console.WriteLine("Press Esc to continue to payment.");
    }

    private void MoveCursor(AuditoriumModel auditorium, ConsoleKey key)
    {
        int newY = _cursorVertical;
        int newX = _cursorHorizontal;

        if (key == ConsoleKey.UpArrow && _cursorVertical > 0) newY--;
        if (key == ConsoleKey.DownArrow && _cursorVertical < auditorium.Seats.GetLength(0) - 1) newY++;
        if (key == ConsoleKey.LeftArrow && _cursorHorizontal > 0) newX--;
        if (key == ConsoleKey.RightArrow && _cursorHorizontal < auditorium.Seats.GetLength(1) - 1) newX++;

        if (_service.CanBookSeat(auditorium, newY, newX))
        {
            _cursorVertical = newY;
            _cursorHorizontal = newX;
        }
    }
}