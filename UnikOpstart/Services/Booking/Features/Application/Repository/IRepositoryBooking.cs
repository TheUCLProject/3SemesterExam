using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Booking.Application.Dtos.Booking;

namespace UnikOpstart.Services.Booking.Application.Repository
{
    public interface IRepositoryBooking
    {
        void Create(BookingEntity booking);
        void Update(BookingEntity booking);
        void Delete(int id);
        QueryResultDtoBooking Get(int id);
        IEnumerable<QueryResultDtoBooking> GetAllByMedarbejderId(int id);
        BookingEntity Load(int id);
        QueryResultDtoBooking GetAvailable(GetRequestDtoBooking request);
    }
}