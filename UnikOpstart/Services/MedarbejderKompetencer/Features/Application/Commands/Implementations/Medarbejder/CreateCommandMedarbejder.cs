using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Medarbejder
{
    public class CreateCommandMedarbejder : ICreateCommand<CreateRequestDtoMedarbejder>
    {
        private readonly IRepositoryMedarbejder _repository;
        private readonly IDomainServiceMedarbejder _domainService;
        public CreateCommandMedarbejder(IRepositoryMedarbejder repository, IDomainServiceMedarbejder domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        void ICreateCommand<CreateRequestDtoMedarbejder>.Create(CreateRequestDtoMedarbejder createRequestDto)
        {
            var entity = new MedarbejderEntity(_domainService, createRequestDto.UserId, createRequestDto.Name, createRequestDto.ProcessRole, createRequestDto.PhoneNr, createRequestDto.Email);
            _repository.Create(entity);
        }
    }
}