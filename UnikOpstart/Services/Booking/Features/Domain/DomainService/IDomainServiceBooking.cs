namespace UnikOpstart.Services.Booking.Domain.DomainService
{
    public interface IDomainServiceBooking
    {
        bool NoBookingsInTimeSpan(int medarbejderId, string startDato, string slutDato);
    }
}