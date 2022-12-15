using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Projekt
{
    public class CreateCommandProjekt : ICreateCommand<CreateRequestDtoProjekt>
    {
        private readonly IRepositoryProjekt _repository;
        private readonly IDomainServiceProjekt _domainService;
        public CreateCommandProjekt(IRepositoryProjekt repository, IDomainServiceProjekt domainServiceProjekt)
        {
            _repository = repository;
            _domainService = domainServiceProjekt;
        }

        void ICreateCommand<CreateRequestDtoProjekt>.Create(CreateRequestDtoProjekt createRequestDtoProjekt)
        {
            var projektEntity = new ProjektEntity(_domainService, 
                                                  createRequestDtoProjekt.KundeId, 
                                                  createRequestDtoProjekt.Name, 
                                                  createRequestDtoProjekt.ContactPerson,
                                                  createRequestDtoProjekt.ActiveProcess,
                                                  createRequestDtoProjekt.Version);

            _repository.Create(projektEntity);
        }
    }
}