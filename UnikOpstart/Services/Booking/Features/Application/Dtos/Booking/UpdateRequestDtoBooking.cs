namespace UnikOpstart.Services.Booking.Application.Dtos.Booking
{
    public class UpdateRequestDtoBooking
    {
        public int Id { get; set; }
        public int OpgaveId { get; set; }
        public string? Title { get; set; }
        public string StartDato { get; set; }
        public string SlutDato { get; set; }
        public string? Kommentar { get; set; }
    }
}