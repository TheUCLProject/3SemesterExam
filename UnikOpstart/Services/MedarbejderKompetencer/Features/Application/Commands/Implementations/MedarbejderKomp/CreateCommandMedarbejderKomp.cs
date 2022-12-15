using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.MedarbejderKomp
{
    public class CreateCommandMedarbejderKomp : ICreateCommand<CreateRequestDtoMedarbejderKomp>
    {
        private readonly IRepositoryMedarbejderKomp _repository;

        public CreateCommandMedarbejderKomp(IRepositoryMedarbejderKomp repository)
        {
            _repository = repository;
        }

        void ICreateCommand<CreateRequestDtoMedarbejderKomp>.Create(CreateRequestDtoMedarbejderKomp dto)
        {
            var entity = new MedarbejderKompEntity(dto.MedarbejderId, dto.KompetenceId);
            _repository.Create(entity);
        }
    }
}
