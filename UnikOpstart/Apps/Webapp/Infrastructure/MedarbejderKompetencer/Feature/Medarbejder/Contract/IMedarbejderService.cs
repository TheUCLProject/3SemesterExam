using Webapp.Infrastructure.Medarbejder.Contract.Dtos;

namespace Webapp.Infrastructure.Medarbejder.Contract
{
    public interface IMedarbejderService
    {
        Task Create(CreateRequestDtoMedarbejder request);
        Task Update(UpdateRequestDtoMedarbejder request);
        Task Delete(int id);
        Task<QueryResultDtoMedarbejder?> Get(int id);
        Task<IEnumerable<QueryResultDtoMedarbejder>?> GetAll();
        Task<IEnumerable<QueryResultDtoMedarbejder>?> GetAllMedarbejderByKompetenceId(int id);
    }
}