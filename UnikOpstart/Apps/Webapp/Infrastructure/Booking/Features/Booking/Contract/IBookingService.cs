using UnikOpstart.Webapp.Infrastructure.Booking.Features.Booking.Contract.Dtos;
using Webapp.Infrastructure.Features.Booking.Contract.Dtos;

namespace Webapp.Infrastructure.Features.Booking.Contract
{
    public interface IBookingService
    {
        Task Create(CreateRequestDtoBooking requestDto);
        Task<IEnumerable<QueryResultDtoBooking>?> GetAllByMedarbejderId(int medarbejderId);
        Task<QueryResultDtoBooking> GetById(int id);
        Task Update(UpdateRequestDtoBooking requestDto);
        Task Delete(int id);
        Task<QueryResultDtoBooking> GetAvailable(GetRequestDtoBooking request);
    }
}