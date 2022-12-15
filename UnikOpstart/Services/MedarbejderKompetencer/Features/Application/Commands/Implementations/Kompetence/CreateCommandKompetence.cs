using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Kompetence
{
    public class CreateCommandKompetence : ICreateCommand<CreateRequestDtoKompetence>
    {
        private readonly IRepositoryKompetence _repository;
        private readonly IDomainServiceKompetence _domainService;

        public CreateCommandKompetence(IRepositoryKompetence repository, IDomainServiceKompetence domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        void ICreateCommand<CreateRequestDtoKompetence>.Create(CreateRequestDtoKompetence dto)
        {
            var entity = new KompetenceEntity(_domainService, dto.Egenskab);
            _repository.Create(entity);
        }
    }
}