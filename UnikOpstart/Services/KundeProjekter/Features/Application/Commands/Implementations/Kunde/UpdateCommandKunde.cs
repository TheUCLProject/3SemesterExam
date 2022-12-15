using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Kunde
{
    public class UpdateCommandKunde : IUpdateCommand<UpdateRequestDtoKunde>
    {
        private readonly IRepositoryKunde _repository;

        public UpdateCommandKunde(IRepositoryKunde repository)
        {
            _repository = repository;
        }

        void IUpdateCommand<UpdateRequestDtoKunde>.Update(UpdateRequestDtoKunde request)
        {
            // Read
            var entity = _repository.Load(request.Id);

            // Do It!
            entity.Update(request.Name, request.Email, request.TlfNr);

            // Save
            _repository.Update(entity);
        }

    }
}