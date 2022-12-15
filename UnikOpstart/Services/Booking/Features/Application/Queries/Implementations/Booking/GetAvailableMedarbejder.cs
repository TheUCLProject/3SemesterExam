using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Application.Repository;

namespace UnikOpstart.Services.Booking.Application.Queries.Implementations.Booking
{
    public class GetAvailableMedarbejderQuery : IGetAvailableMedarbejderQuery
    {
        private readonly IRepositoryBooking _repository;
        public GetAvailableMedarbejderQuery(IRepositoryBooking repository)
        {
            _repository = repository;
        }

        public QueryResultDtoBooking GetAvailableMedarbejder(GetRequestDtoBooking request)
        {
            return _repository.GetAvailable(request);
        }
    }
}