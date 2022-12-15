using UnikOpstart.Services.Booking.Application.Dtos.Booking;

namespace UnikOpstart.Services.Booking.Application.Queries
{
    public interface IGetAvailableMedarbejderQuery
    {
        QueryResultDtoBooking GetAvailableMedarbejder(GetRequestDtoBooking request);
    }
}