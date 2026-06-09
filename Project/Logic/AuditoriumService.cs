using System;
using System.Collections.Generic;

public class AuditoriumService
{
    private readonly AuditoriumRepository _repository;

    public AuditoriumService(AuditoriumRepository repository)
    {
        _repository = repository;
    }

    public AuditoriumModel LoadAuditorium(string auditoriumNumber)
    {
        return _repository.GetAuditorium(auditoriumNumber);
    }

    public void SetReservedSeats(AuditoriumModel auditorium, List<string> reservedSeats)
    {
        foreach (string seat in reservedSeats)
        {
            var (row, column) = SeatToIndexes(seat);

            if (auditorium.Seats[row, column] != SeatType.Empty)
            {
                auditorium.Seats[row, column] = SeatType.Reserved;
            }
        }
    }

    public bool CanBookSeat(AuditoriumModel auditorium, int row, int column)
    {
        return auditorium.Seats[row, column] != SeatType.Empty &&
               auditorium.Seats[row, column] != SeatType.Reserved;
    }

    public void BookSeat(AuditoriumModel auditorium, Reservation reservation, int row, int column)
    {
        if (reservation.Seats.Count >= 10)
            throw new Exception("You can't book more than 10 seats.");

        SeatType seatType = auditorium.Seats[row, column];

        if (!CanBookSeat(auditorium, row, column))
            throw new Exception("This seat cannot be booked.");

        string seatKey = IndexesToSeat(row, column);
        reservation.Seats[seatKey] = GetSeatPrice(seatType);

        // gekozen seat veranderen naar gereserveert
        auditorium.Seats[row, column] = SeatType.Reserved;
    }

    public decimal GetSeatPrice(SeatType seatType)
    {
        return seatType switch
        {
            SeatType.Basic => 11.00m,
            SeatType.Comfort => 12.00m,
            SeatType.Premium => 14.00m,
            _ => 0m
        };
    }

    public (int row, int column) SeatToIndexes(string seat)
    {
        char rowLetter = seat[0];
        int seatNumber = int.Parse(seat.Substring(1));

        return (rowLetter - 'A', seatNumber - 1);
    }

    public string IndexesToSeat(int row, int column)
    {
        char rowLetter = (char)('A' + row);
        int seatNumber = column + 1;

        return $"{rowLetter}{seatNumber}";
    }
}