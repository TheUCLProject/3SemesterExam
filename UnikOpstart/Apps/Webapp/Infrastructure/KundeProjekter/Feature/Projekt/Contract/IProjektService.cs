using Webapp.Infrastructure.Projekt.Contract.Dtos;

namespace Webapp.Infrastructure.Projekt.Contract
{
    public interface IProjektService
    {
        Task Create(CreateRequestDtoProjekt request);
        Task Edit(UpdateRequestDtoProjekt request);
        Task Delete(int id);
        Task<QueryResultDtoProjekt?> Get(int id);
        Task<IEnumerable<QueryResultDtoProjekt>?> GetAll();
        Task<IEnumerable<QueryResultDtoProjekt>?> GetAllByKundeId(int kundeId);
    }
}