using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Projekt
{
    public class GetAllProjekterByKundeId : IGetAllProjekterByKundeId
    {

        private readonly IRepositoryProjekt _repository;

        public GetAllProjekterByKundeId(IRepositoryProjekt repository)
        {
             _repository = repository;
        }

        IEnumerable<QueryResultDtoProjekt> IGetAllProjekterByKundeId.GetAllProjekterByKundeId(int kundeId)
        {
            return _repository.GetAllProjekterByKundeId(kundeId);
        }
    }
}