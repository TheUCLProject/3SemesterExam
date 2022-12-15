using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Projekt
{
    public class GetQueryProjekt : IGetQuery<QueryResultDtoProjekt>
    {

        private readonly IRepositoryProjekt _repository;
        public GetQueryProjekt(IRepositoryProjekt repository)
        {
            _repository = repository;
        }
        QueryResultDtoProjekt IGetQuery<QueryResultDtoProjekt>.Get(int id)
        {
            return _repository.Get(id);
        }

    }
}