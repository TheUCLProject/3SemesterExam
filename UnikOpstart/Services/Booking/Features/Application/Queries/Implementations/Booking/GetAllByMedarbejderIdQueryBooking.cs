using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Application.Queries;

namespace UnikOpstart.Services.Booking.Application.Queries.Implementations.Booking
{
    public class GetAllByMedarbejderIdQueryBooking : IGetAllByMedarbejderIdQuery<QueryResultDtoBooking>
    {
        private readonly IRepositoryBooking _repository;
        public GetAllByMedarbejderIdQueryBooking(IRepositoryBooking repository)
        {
            _repository = repository;
        }

        IEnumerable<QueryResultDtoBooking> IGetAllByMedarbejderIdQuery<QueryResultDtoBooking>.GetAllByMedarbejderId(int id)
        {
            return _repository.GetAllByMedarbejderId(id);
        }
    }
}