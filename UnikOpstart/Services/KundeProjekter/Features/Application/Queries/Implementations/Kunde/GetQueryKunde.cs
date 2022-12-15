using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Kunde
{
    public class GetQueryKunde : IGetQuery<QueryResultDtoKunde>
    {
        private readonly IRepositoryKunde _repositoryKunde;

        public GetQueryKunde(IRepositoryKunde repositoryKunde)
        {
            _repositoryKunde = repositoryKunde;
        }

        QueryResultDtoKunde IGetQuery<QueryResultDtoKunde>.Get(int id)
        {
            return _repositoryKunde.Get(id);
        }
    }
}