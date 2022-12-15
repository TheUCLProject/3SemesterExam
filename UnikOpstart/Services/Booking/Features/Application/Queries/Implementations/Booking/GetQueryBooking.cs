using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Application.Queries;

namespace UnikOpstart.Services.Booking.Application.Queries.Implementations.Booking
{
    public class GetQueryBooking : IGetQuery<QueryResultDtoBooking>
    {
        private readonly IRepositoryBooking _repository;
        public GetQueryBooking(IRepositoryBooking repository)
        {
            _repository = repository;
        }

        QueryResultDtoBooking IGetQuery<QueryResultDtoBooking>.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}