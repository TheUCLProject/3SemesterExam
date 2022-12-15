using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Kunde
{
    public class GetAllQueryKunde : IGetAllQuery<QueryResultDtoKunde>
    {
        private readonly IRepositoryKunde _repositoryKunde;

        public GetAllQueryKunde(IRepositoryKunde repositoryKunde)
        {
            _repositoryKunde = repositoryKunde;
        }

        IEnumerable<QueryResultDtoKunde> IGetAllQuery<QueryResultDtoKunde>.GetAll()
        {
            return _repositoryKunde.GetAll();
        }
    }
}