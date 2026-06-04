public class MovieService
{
    public void RunAuditorium(
        Movie selectedMovie,
        MovieShowing selectedShowing,
        AccountModel? account)
    {
        HandleDinnerEventInfo(selectedShowing, account);

        Auditorium auditorium = new Auditorium(selectedShowing.Auditorium);
        TicketService ticketService = new TicketService();

        List<string> reservedSeats =
            ticketService.ReservedTickets(
                selectedShowing.Auditorium,
                selectedShowing.StartTime.ToString("dddd dd MMMM - HH:mm"));

        auditorium.SetReservedSeats(reservedSeats);

        Dictionary<string, Dictionary<string, decimal>> selectedSeats =
            auditorium.StartSelection(
                selectedMovie.Title,
                selectedShowing.StartTime.ToString("dddd dd MMMM - HH:mm"));

        ApplyDinnerEventPricing(selectedShowing, selectedSeats);

        ProcessPayment(selectedMovie, selectedShowing, selectedSeats, account);
    }

    private void HandleDinnerEventInfo(
        MovieShowing showing,
        AccountModel? account)
    {
        if (!showing.IsDinnerEvent)
            return;

        bool shouldAskInfo =
            account == null ||
            (account.Allergie == null &&
             account.Dieet == null &&
             account.Opmerkingen == null);

        if (!shouldAskInfo)
            return;

        string? allergies = Diet.AskForAllergies();
        string? diet = Diet.AskForDietaryPreferences();
        string? comments = Diet.AskForAdditionalComments();

        if (account != null)
        {
            EditAccountLogic.EditDiet(account, allergies, diet, comments);
        }
    }

    private void ApplyDinnerEventPricing(
        MovieShowing showing,
        Dictionary<string, Dictionary<string, decimal>> selectedSeats)
    {
        if (!showing.IsDinnerEvent)
            return;

        foreach (var innerDict in selectedSeats.Values)
        {
            foreach (var key in innerDict.Keys.ToList())
            {
                innerDict[key] += 50m;
            }
        }
    }

    private void ProcessPayment(
        Movie movie,
        MovieShowing showing,
        Dictionary<string, Dictionary<string, decimal>> selectedSeats,
        AccountModel? account)
    {
        PaymentUI paymentUI = new PaymentUI(account != null);

        paymentUI.StartAsMember(
            movie.Title,
            showing.StartTime.ToString("dddd dd MMMM - HH:mm"),
            selectedSeats,
            account?.Email);
    }
}