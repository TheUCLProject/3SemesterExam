namespace Webapp.Pages.Booking.ViewModels
{
    public class CreateViewModelBooking
    {
        public int MedarbejderId { get; set; }
        public string? Title { get; set; }
        public string? StartDato { get; set; }
        public string? SlutDato { get; set; }
        public string? Kommentar { get; set; }
    }
}