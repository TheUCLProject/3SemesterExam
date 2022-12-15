using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Application.Commands;

namespace UnikOpstart.Services.Booking.Application.Commands.Implementations.Booking
{
    public class UpdateCommandBooking : IUpdateCommand<UpdateRequestDtoBooking>
    {
        private readonly IRepositoryBooking _repository;

        public UpdateCommandBooking(IRepositoryBooking repository)
        {
            _repository = repository;
        }

        void IUpdateCommand<UpdateRequestDtoBooking>.Update(UpdateRequestDtoBooking request)
        {
            var model = _repository.Load(request.Id);

            model.Update(request.OpgaveId, 
                         request.Title, 
                         request.StartDato,
                         request.SlutDato, 
                         request.Kommentar);

            _repository.Update(model);
        }
    }
}