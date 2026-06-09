using System;

public class AuditoriumRepository
    {
        public AuditoriumModel GetAuditorium(string auditoriumNumber)
        {
            SeatType[,] layout = GenerateLayout(auditoriumNumber);

            return new AuditoriumModel(auditoriumNumber, layout);
        }

        private SeatType[,] GenerateLayout(string auditoriumNumber)
        {
            SeatType[,] layout;

            if (auditoriumNumber == "Auditorium 1")
            {
                layout = new SeatType[14, 12]; // verticaal, horizontaal

                // alles blauw maken
                for (int r = 0; r < 14; r++)
                {
                    for (int c = 0; c < 12; c++)
                    {
                        layout[r, c] = SeatType.Basic;
                    }
                }

                // plek zonder stoel waarde 0 geven
                // links boven
                layout[0, 0] = SeatType.Empty;
                layout[0, 1] = SeatType.Empty;
                layout[1, 0] = SeatType.Empty;
                layout[2, 0] = SeatType.Empty;

                // rechts boven
                layout[0, 11] = SeatType.Empty;
                layout[0, 10] = SeatType.Empty;
                layout[1, 11] = SeatType.Empty;
                layout[2, 11] = SeatType.Empty;

                // gele deel
                for (int ver = 3; ver < 11; ver++)
                {
                    for (int horizontal = 3; horizontal < 9; horizontal++)
                    {
                        layout[ver, horizontal] = SeatType.Comfort;
                    }
                }

                // rode deel
                for (int r = 5; r < 9; r++)
                {
                    for (int c = 5; c < 7; c++)
                    {
                        layout[r, c] = SeatType.Premium;
                    }
                }

                return layout;
            }
            else if (auditoriumNumber == "Auditorium 2")
            {
                layout = new SeatType[19, 18];

                // Paste your Auditorium 2 code here
                return layout;
            }
            else if (auditoriumNumber == "Auditorium 3")
            {
                layout = new SeatType[20, 30];

                // Paste your Auditorium 3 code here
                return layout;
            }

            throw new Exception("Onbekend auditorium nummer!");
        }
    }

    // in deze repository staan de zalen met hun layout, deze worden gebruikt in de auditorium class om de zaal te genereren
    // in de auditorium class worden de gereserveerde stoelen opgehaald en wordt de layout aangepast, deze wordt vervolgens gebruikt in de auditorium view om de zaal te tonen en de stoelen te selecteren
    // in de reservation.cs staat welke stoelen er gereserveerd zijn, deze worden gebruikt in de auditorium repository om de layout aan te passen
    // in SeatsType.cs staan de verschillende soorten stoelen, deze worden gebruikt in de auditorium repository om de layout aan te passen en in de reservation.cs om de prijs van de stoelen te bepalen