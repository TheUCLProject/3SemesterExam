namespace UnikOpstart.Services.Booking.Application.Dtos.Booking
{
    public class GetRequestDtoBooking
    {
        public int MedarbejderId { get; set; }
        public string StartDato { get; set; }
        public string SlutDato { get; set; }
    }
}