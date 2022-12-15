using UnikOpstart.Services.Booking.Application.Commands;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Domain.Models;

namespace UnikOpstart.Services.Booking.Application.Commands.Implementations.Booking
{
    public class DeleteCommandBooking : IDeleteCommand<BookingEntity>
    {
        private readonly IRepositoryBooking _repository;

        public DeleteCommandBooking(IRepositoryBooking repository)
        {
            _repository = repository;
        }

        void IDeleteCommand<BookingEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
    
}