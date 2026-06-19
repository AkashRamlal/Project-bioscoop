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

                layout[11, 0] = SeatType.Empty; layout[12, 0] = SeatType.Empty; layout[13, 0] = SeatType.Empty; layout[12, 1] = SeatType.Empty; layout[13, 1] = SeatType.Empty;

                layout[13, 11] = SeatType.Empty; layout[13, 10] = SeatType.Empty; layout[12, 10] = SeatType.Empty; layout[11, 11] = SeatType.Empty; layout[12, 11] = SeatType.Empty;

                // gele deel
                for (int ver = 3; ver < 11; ver++)
                {
                    for (int horizontal = 3; horizontal < 9; horizontal++)
                    {
                        layout[ver, horizontal] = SeatType.Comfort;
                    }
                }

                layout[3, 3] = SeatType.Basic; layout[3, 4] = SeatType.Basic; layout[3, 7] = SeatType.Basic; layout[3, 8] = SeatType.Basic; layout[4, 3] = SeatType.Basic; layout[4, 8] = SeatType.Basic; layout[9, 3] = SeatType.Basic; 
                layout[9, 8] = SeatType.Basic; layout[10, 3] = SeatType.Basic; layout[10, 4] = SeatType.Basic; layout[10, 7] = SeatType.Basic; layout[10, 8] = SeatType.Basic; 


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
                for (int ver = 0; ver < 19; ver++)
                    for (int hor = 0; hor < 18; hor++)
                        layout[ver, hor] = SeatType.Basic;
                
                layout[0, 0] = SeatType.Empty; layout[1, 0] = SeatType.Empty; layout[2, 0] = SeatType.Empty; layout[3, 0] = SeatType.Empty; layout[4, 0] = SeatType.Empty; layout[5, 0] = SeatType.Empty; layout[0, 17] = SeatType.Empty; layout[1, 17] = SeatType.Empty; layout[3, 17] = SeatType.Empty; layout[4, 17] = SeatType.Empty; layout[5, 17] = SeatType.Empty; layout[2, 17] = SeatType.Empty; layout[14, 0] = SeatType.Empty; layout[13, 0] = SeatType.Empty; layout[11, 17] = SeatType.Empty;
                layout[12, 0] = SeatType.Empty; layout[13, 0] = SeatType.Empty; layout[14, 0] = SeatType.Empty; layout[16, 0] = SeatType.Empty; layout[17, 0] = SeatType.Empty; layout[15, 0] = SeatType.Empty; layout[18, 0] = SeatType.Empty; layout[12, 17] = SeatType.Empty; layout[13, 17] = SeatType.Empty; layout[14, 17] = SeatType.Empty; layout[15, 17] = SeatType.Empty; layout[16, 17] = SeatType.Empty; layout[17, 17] = SeatType.Empty; layout[18, 17] = SeatType.Empty; layout[11, 0] = SeatType.Empty;
                layout[14, 1] = SeatType.Empty; layout[15, 1] = SeatType.Empty; layout[16, 1] = SeatType.Empty; layout[17, 2] = SeatType.Empty; layout[18, 1] = SeatType.Empty;  layout[17, 1] = SeatType.Empty;layout[18, 2] = SeatType.Empty; 
                layout[14, 16] = SeatType.Empty; layout[15, 16] = SeatType.Empty; layout[16, 16] = SeatType.Empty; layout[17, 16] = SeatType.Empty;layout[18, 16] = SeatType.Empty; layout[17, 15] = SeatType.Empty; layout[18, 15] = SeatType.Empty;
                
                for (int verGeel = 1; verGeel < 16; verGeel++)
                    for (int horGeel = 2; horGeel < 16; horGeel++)
                        layout[verGeel, horGeel] = SeatType.Comfort;

                layout[1, 2] = SeatType.Basic; layout[2, 2] = SeatType.Basic; layout[3, 2] = SeatType.Basic; layout[4 , 2] = SeatType.Basic; layout[5, 2] = SeatType.Basic;
                layout[1, 3] = SeatType.Basic; layout[2, 3] = SeatType.Basic; layout[3, 3] = SeatType.Basic; 
                layout[1, 4] = SeatType.Basic;
                layout[1, 5] = SeatType.Basic;
                layout[2, 4] = SeatType.Basic;
                layout[1, 5] = SeatType.Basic; 


                layout[1, 15] = SeatType.Basic; layout[2, 15] = SeatType.Basic;  layout[3, 15] = SeatType.Basic;  layout[4, 15] = SeatType.Basic;  layout[5, 15] = SeatType.Basic; layout[6, 15] = SeatType.Basic; layout[1, 14] =SeatType.Basic; layout[2, 14] = SeatType.Basic; layout[3, 14] = SeatType.Basic; layout[4 , 14] = SeatType.Basic; layout[1, 13] = SeatType.Basic; layout[2, 13] = SeatType.Basic; layout[1, 12] = SeatType.Basic; layout[7, 2] = SeatType.Basic; layout[6, 2] = SeatType.Basic; layout[7, 15] = SeatType.Basic;
                layout[11, 2] = SeatType.Basic; layout[12, 2] = SeatType.Basic; layout[13, 2] = SeatType.Basic; layout[14, 2] = SeatType.Basic; layout[12, 3] = SeatType.Basic; layout[13, 3] = SeatType.Basic; layout[14, 3] = SeatType.Basic; layout[13, 4] = SeatType.Basic; layout[14, 4] = SeatType.Basic;
            
                layout[15, 2] = SeatType.Basic; layout[15, 3] = SeatType.Basic; layout[15, 4] = SeatType.Basic; layout[11, 15] = SeatType.Basic; layout[12, 15] = SeatType.Basic; layout[13, 15] = SeatType.Basic; layout[14, 15] = SeatType.Basic; layout[15, 15] = SeatType.Basic; layout[12, 14] = SeatType.Basic; layout[13, 14] = SeatType.Basic; layout[14, 14] = SeatType.Basic; layout[15, 14] = SeatType.Basic;  layout[13, 13] = SeatType.Basic; layout[14, 13] = SeatType.Basic ;  layout[15, 13] = SeatType.Basic; layout[14, 12] = SeatType.Basic; layout[15, 12] = SeatType.Basic; 

                layout[15, 5] = SeatType.Basic; layout[14, 5] = SeatType.Basic;   




                for (int verRood = 5; verRood < 13; verRood++)
                    for (int horRood = 6; horRood < 12; horRood++)
                        layout[verRood, horRood] = SeatType.Premium;

                layout[5, 6] = SeatType.Comfort; layout[6, 6] = SeatType.Comfort; layout[11, 6] = SeatType.Comfort; layout[12, 6] = SeatType.Comfort; layout[5, 7] = SeatType.Comfort; layout[12, 7] = SeatType.Comfort;
                layout[5, 10] = SeatType.Comfort; layout[5, 11] = SeatType.Comfort; layout[6, 11] = SeatType.Comfort;
                layout[11, 11] = SeatType.Comfort; layout[12, 11] = SeatType.Comfort; layout[12, 10] = SeatType.Comfort;
    
            return layout;

            }

            else if (auditoriumNumber == "Auditorium 3")
            {
                layout = new SeatType[20, 30];
                for (int verBlauw = 0; verBlauw < 20; verBlauw++)
                    for (int horBlauw = 0; horBlauw < 30; horBlauw++)
                        layout[verBlauw, horBlauw] = SeatType.Basic;

                layout[0, 0] = SeatType.Empty; layout[0, 1] = SeatType.Empty; layout[0, 2] = SeatType.Empty; layout[0, 3] = SeatType.Empty;
                layout[1, 0] = SeatType.Empty; layout[1, 1] = SeatType.Empty; layout[1, 2] = SeatType.Empty; 
                layout[2, 0] = SeatType.Empty;  layout[2, 1] = SeatType.Empty;  layout[2, 2] = SeatType.Empty; 
                layout[3, 0] = SeatType.Empty; layout[3, 1] = SeatType.Empty; layout[3, 2] = SeatType.Empty; 
                layout[4, 0] = SeatType.Empty; layout[4, 1] = SeatType.Empty; layout[4, 2] = SeatType.Empty; 
                layout[5, 0] = SeatType.Empty; layout[5, 1] = SeatType.Empty; 
                layout[6, 0] = SeatType.Empty; 

                layout[0, 26] = SeatType.Empty; layout[0, 27] = SeatType.Empty; layout[0, 28] = SeatType.Empty; layout[0, 29] = SeatType.Empty; 
                layout[1, 27] = SeatType.Empty; layout[1, 28] = SeatType.Empty; layout[1, 29] = SeatType.Empty; 
                layout[2, 27] = SeatType.Empty; layout[2, 28] = SeatType.Empty; layout[2, 29] = SeatType.Empty; 
                layout[3, 27] = SeatType.Empty; layout[3, 28] = SeatType.Empty; layout[3, 29] = SeatType.Empty; 
                layout[4, 27] = SeatType.Empty; layout[4, 28] = SeatType.Empty; layout[4, 29] = SeatType.Empty; 
                layout[5, 28] = SeatType.Empty; layout[5, 29] = SeatType.Empty; 
                layout[6, 29] = SeatType.Empty; 

                layout[12, 0] = SeatType.Empty; 
                layout[13, 0] = SeatType.Empty; layout[13, 1] = SeatType.Empty; 
                layout[14, 0] = SeatType.Empty; layout[14, 1] = SeatType.Empty; 
                layout[15, 0] = SeatType.Empty; layout[15, 1] = SeatType.Empty; layout[15, 2] = SeatType.Empty; 
                layout[16, 0] = SeatType.Empty; layout[16, 1] = SeatType.Empty; layout[16, 2] = SeatType.Empty;
                layout[17, 0] = SeatType.Empty; layout[17, 1] = SeatType.Empty; layout[17, 2] = SeatType.Empty; layout[17, 3] = SeatType.Empty; layout[17, 4] = SeatType.Empty; 
                layout[18, 0] = SeatType.Empty; layout[18, 1] = SeatType.Empty; layout[18, 2] = SeatType.Empty; layout[18, 3] = SeatType.Empty; layout[18, 4] = SeatType.Empty; layout[18, 5] = SeatType.Empty; layout[18, 6] = SeatType.Empty; 
                layout[19, 0] = SeatType.Empty; layout[19, 1] = SeatType.Empty; layout[19, 2] = SeatType.Empty; layout[19, 3] = SeatType.Empty; layout[19, 4] = SeatType.Empty; layout[19, 5] = SeatType.Empty; layout[19, 6] = SeatType.Empty; layout[19, 7] = SeatType.Empty; 

                layout[12, 29] = SeatType.Empty; 
                layout[13, 29] = SeatType.Empty; layout[13, 28] = SeatType.Empty; 
                layout[14, 29] = SeatType.Empty; layout[14, 28] = SeatType.Empty; 
                layout[15, 29] = SeatType.Empty; layout[15, 28] = SeatType.Empty; layout[15, 27] = SeatType.Empty; 
                layout[16, 29] = SeatType.Empty; layout[16, 28] = SeatType.Empty; layout[16, 27] = SeatType.Empty;
                layout[17, 29] = SeatType.Empty; layout[17, 28] = SeatType.Empty; layout[17, 27] = SeatType.Empty; layout[17, 26] = SeatType.Empty; layout[17, 25] = SeatType.Empty; 
                layout[18, 29] = SeatType.Empty; layout[18, 28] = SeatType.Empty; layout[18, 27] = SeatType.Empty; layout[18, 26] = SeatType.Empty; layout[18, 25] = SeatType.Empty; layout[18, 24] = SeatType.Empty; layout[18, 23] = SeatType.Empty; 
                layout[19, 29] = SeatType.Empty; layout[19, 28] = SeatType.Empty; layout[19, 27] = SeatType.Empty; layout[19, 26] = SeatType.Empty; layout[19, 25] = SeatType.Empty; layout[19, 24] = SeatType.Empty; layout[19, 23] = SeatType.Empty; layout[19, 22] = SeatType.Empty; 
           
                for (int verGeel = 1; verGeel < 17; verGeel++)
                    for (int horGeel = 5; horGeel < 25; horGeel++)
                        layout[verGeel, horGeel] = SeatType.Comfort;
                layout[1, 5] = SeatType.Basic; layout[1, 6] = SeatType.Basic; layout[1, 7] = SeatType.Basic; layout[1, 8] = SeatType.Basic; 
                layout[2, 5] = SeatType.Basic; layout[2, 6] = SeatType.Basic; layout[2, 7] = SeatType.Basic;
                layout[3, 5] = SeatType.Basic; layout[3, 6] = SeatType.Basic; layout[3, 7] = SeatType.Basic;
                layout[4, 5] = SeatType.Basic; layout[4, 6] = SeatType.Basic;
                layout[5, 5] = SeatType.Basic; layout[5, 6] = SeatType.Basic;
                layout[6, 5] = SeatType.Basic;
                layout[7, 5] = SeatType.Basic;

                
                layout[1, 24] = SeatType.Basic; layout[1, 23] = SeatType.Basic; layout[1, 22] = SeatType.Basic; layout[1, 21] = SeatType.Basic; 
                layout[2, 24] = SeatType.Basic; layout[2, 23] = SeatType.Basic; layout[2, 22] = SeatType.Basic;
                layout[3, 24] = SeatType.Basic; layout[3, 23] = SeatType.Basic; layout[3, 22] = SeatType.Basic;
                layout[4, 24] = SeatType.Basic; layout[4, 23] = SeatType.Basic;
                layout[5, 24] = SeatType.Basic; layout[5, 23] = SeatType.Basic;
                layout[6, 24] = SeatType.Basic;
                layout[7, 24] = SeatType.Basic;

                layout[10, 5] = SeatType.Basic;
                layout[11, 5] = SeatType.Basic; layout[11, 6] = SeatType.Basic; 
                layout[12, 5] = SeatType.Basic; layout[12, 6] = SeatType.Basic; layout[12, 7] = SeatType.Basic; 
                layout[13, 5] = SeatType.Basic; layout[13, 6] = SeatType.Basic; layout[13, 7] = SeatType.Basic; 
                layout[14, 5] = SeatType.Basic; layout[14, 6] = SeatType.Basic; layout[14, 7] = SeatType.Basic; layout[14, 8] = SeatType.Basic; 
                layout[15, 5] = SeatType.Basic; layout[15, 6] = SeatType.Basic; layout[15, 7] = SeatType.Basic;  layout[15, 8] = SeatType.Basic; layout[15, 9] = SeatType.Basic; 
                layout[16, 5] = SeatType.Basic; layout[16, 6] = SeatType.Basic; layout[16, 7] = SeatType.Basic;  layout[16, 8] = SeatType.Basic; layout[16, 9] = SeatType.Basic; layout[16, 10] = SeatType.Basic; layout[16, 11] = SeatType.Basic;

                layout[10, 24] = SeatType.Basic;
                layout[11, 24] = SeatType.Basic; layout[11, 23] = SeatType.Basic; 
                layout[12, 24] = SeatType.Basic; layout[12, 23] = SeatType.Basic; layout[12, 22] = SeatType.Basic; 
                layout[13, 24] = SeatType.Basic; layout[13, 23] = SeatType.Basic; layout[13, 22] = SeatType.Basic; 
                layout[14, 24] = SeatType.Basic; layout[14, 23] = SeatType.Basic; layout[14, 22] = SeatType.Basic; layout[14, 21] = SeatType.Basic; 
                layout[15, 24] = SeatType.Basic; layout[15, 23] = SeatType.Basic; layout[15, 22] = SeatType.Basic;  layout[15, 21] = SeatType.Basic; layout[15, 20] = SeatType.Basic; 
                layout[16, 24] = SeatType.Basic; layout[16, 23] = SeatType.Basic; layout[16, 22] = SeatType.Basic;  layout[16, 21] = SeatType.Basic; layout[16, 20] = SeatType.Basic; layout[16, 19] = SeatType.Basic; layout[16, 18] = SeatType.Basic;


                for (int verRood = 4; verRood < 14; verRood++)
                    for (int horRood = 11; horRood < 19; horRood++)
                        layout[verRood, horRood] = SeatType.Premium;
                layout[4 , 11] = SeatType.Comfort; layout[4 , 12] = SeatType.Comfort;
                layout[5 , 11] = SeatType.Comfort;

                layout[4 , 18] = SeatType.Comfort; layout[4 , 17] = SeatType.Comfort;
                layout[5 , 18] = SeatType.Comfort;

                layout[13, 11] = SeatType.Comfort; layout[13, 12 ] = SeatType.Comfort;
                layout[13, 17] = SeatType.Comfort; layout[13, 18 ] = SeatType.Comfort;
                return layout;
            }
            
            throw new Exception("Onbekend auditorium nummer!");
        }}
    

    // in deze repository staan de zalen met hun layout, deze worden gebruikt in de auditorium class om de zaal te genereren
    // in de auditorium class worden de gereserveerde stoelen opgehaald en wordt de layout aangepast, deze wordt vervolgens gebruikt in de auditorium view om de zaal te tonen en de stoelen te selecteren
    // in de reservation.cs staat welke stoelen er gereserveerd zijn, deze worden gebruikt in de auditorium repository om de layout aan te passen
    // in SeatsType.cs staan de verschillende soorten stoelen, deze worden gebruikt in de auditorium repository om de layout aan te passen en in de reservation.cs om de prijs van de stoelen te bepalen