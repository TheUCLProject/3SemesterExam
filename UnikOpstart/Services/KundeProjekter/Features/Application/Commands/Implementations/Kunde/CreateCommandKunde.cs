using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Kunde
{
    public class CreateCommandKunde : ICreateCommand<CreateRequestDtoKunde>
    {

        private readonly IRepositoryKunde _repository;

        public CreateCommandKunde(IRepositoryKunde repository)
        {
            _repository = repository;
        }

        void ICreateCommand<CreateRequestDtoKunde>.Create(CreateRequestDtoKunde request)
        {
            var entity = new KundeEntity(request.UserId, request.Name, request.Email, request.TlfNr);
            _repository.Create(entity);

        }

    }
}