namespace UnikOpstart.Webapp.Infrastructure.Booking.Features.Booking.Contract.Dtos
{
    public class GetRequestDtoBooking
    {
        public int MedarbejderId { get; set; }
        public string StartDato { get; set; }
        public string SlutDato { get; set; }
    }
}