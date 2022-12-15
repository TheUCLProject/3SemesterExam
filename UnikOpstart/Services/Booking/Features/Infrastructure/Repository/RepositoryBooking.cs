using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Database.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace UnikOpstart.Services.Booking.Infrastructure.Repository
{
    public class RepositoryBooking : IRepositoryBooking
    {
        private readonly BookingContext _db;

        public RepositoryBooking(BookingContext db)
        {
            _db = db;
        }

        void IRepositoryBooking.Create(BookingEntity booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        void IRepositoryBooking.Update(BookingEntity booking)
        {
            _db.Bookings.Update(booking);
            _db.SaveChanges();
        }

        void IRepositoryBooking.Delete(int id)
        {
            var booking = _db.Bookings.Find(id);
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
        }

        QueryResultDtoBooking IRepositoryBooking.Get(int id)
        {
            var entity = _db.Bookings.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity == null) throw new ArgumentException("Booking findes ikke");
            return new QueryResultDtoBooking { Id = entity.Id, Title = entity.Title, StartDato = entity.StartDato, SlutDato = entity.SlutDato };
        }

        IEnumerable<QueryResultDtoBooking> IRepositoryBooking.GetAllByMedarbejderId(int id)
        {
            foreach (var entity in _db.Bookings.AsNoTracking().Where(x => x.MedarbejderId == id).ToList())
                yield return new QueryResultDtoBooking 
                {   Id = entity.Id, 
                    MedarbejderId = entity.MedarbejderId,
                    OpgaveId = entity.OpgaveId,
                    Title = entity.Title, 
                    StartDato = entity.StartDato, 
                    SlutDato = entity.SlutDato,
                    Kommentar = entity.Kommentar
                };
        }

        BookingEntity IRepositoryBooking.Load(int id)
        {
            var entity = _db.Bookings.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity == null) throw new ArgumentException("Booking findes ikke i database");
            return entity;
        }

        QueryResultDtoBooking IRepositoryBooking.GetAvailable(GetRequestDtoBooking request)
        {
            var entity = _db.Bookings.AsNoTracking().FirstOrDefault(x => x.StartDato.ToString() == request.StartDato && x.SlutDato.ToString() == request.SlutDato);
            if (entity == null) throw new ArgumentException("Ingen ledige!");
            return new QueryResultDtoBooking { Id = entity.Id, MedarbejderId = entity.MedarbejderId, Title = entity.Title, StartDato = entity.StartDato.ToString(), SlutDato = entity.SlutDato.ToString() };
        }
   }
}