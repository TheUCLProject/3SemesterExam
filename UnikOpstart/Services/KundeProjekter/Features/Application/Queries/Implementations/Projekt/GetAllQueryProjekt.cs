using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Projekt
{
    public class GetAllQueryProjekt : IGetAllQuery<QueryResultDtoProjekt>
    {

        private readonly IRepositoryProjekt _repository;
        public GetAllQueryProjekt(IRepositoryProjekt repository)
        {
            _repository = repository;
        }
        IEnumerable<QueryResultDtoProjekt> IGetAllQuery<QueryResultDtoProjekt>.GetAll()
        {
            return _repository.GetAll();
        }
    }
}