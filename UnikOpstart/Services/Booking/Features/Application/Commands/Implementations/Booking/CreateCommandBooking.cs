using UnikOpstart.Services.Booking.Domain.Models;
using UnikOpstart.Services.Booking.Application.Dtos.Booking;
using UnikOpstart.Services.Booking.Application.Repository;
using UnikOpstart.Services.Booking.Crosscut.TransactionHandling;

namespace UnikOpstart.Services.Booking.Application.Commands.Implementations.Booking
{
    public class CreateCommandBooking : ICreateCommand<CreateRequestDtoBooking>
    {
        private readonly IRepositoryBooking _repository;
        private readonly IUnitOfWork _uow;

        public CreateCommandBooking(IRepositoryBooking repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        void ICreateCommand<CreateRequestDtoBooking>.Create(CreateRequestDtoBooking request)
        {
            _uow.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                var entity = new BookingEntity(request.MedarbejderId,
                                request.OpgaveId,
                                request.Title,
                                request.StartDato,
                                request.SlutDato,
                                request.Kommentar);
                _repository.Create(entity);

                _uow.Commit();
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
        }
    }
}