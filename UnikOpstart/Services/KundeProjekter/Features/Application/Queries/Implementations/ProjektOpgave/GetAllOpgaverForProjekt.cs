using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.ProjektOpgave
{
    public class GetAllOpgaverForProjekt : IGetAllOpgaverForProjekt
    {

        private readonly IRepositoryProjektOpgave _repository;
        public GetAllOpgaverForProjekt(IRepositoryProjektOpgave repository)
        {
            _repository = repository;
        }

        IEnumerable<QueryResultDtoProjektOpgave> IGetAllOpgaverForProjekt.GetAllOpgaverForProjekt(int projektId)
        {
            return _repository.GetAllOpgaverForProjekt(projektId);
        }
    }
}