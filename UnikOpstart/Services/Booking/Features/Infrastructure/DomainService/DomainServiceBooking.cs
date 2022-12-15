using UnikOpstart.Services.Booking.Domain.DomainService;
using UnikOpstart.Services.Booking.Database.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace UnikOpstart.Services.Booking.Infrastructure.DomainService.Implementation
{
    public class DomainServiceBooking : IDomainServiceBooking
    {
        private readonly BookingContext _db;

        public DomainServiceBooking(BookingContext db)
        {
            _db = db;
        }

        bool IDomainServiceBooking.NoBookingsInTimeSpan(int medarbejderId, string startDato, string slutDato)
        {
            // var bookings = _db.Bookings
            //     .FromSqlRaw("SELECT * FROM Bookings WHERE MedarbejderId = {0} AND StartDato < {1} AND SlutDato > {2}",
            return false;
        }
    }
    
}