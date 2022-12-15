using Webapp.Infrastructure.Opgaver.Contract.Dtos;

namespace Webapp.Infrastructure.Opgaver.Contract;

public interface IOpgaverService
{
    Task Create(CreateRequestDtoOpgaver request);
    Task<QueryResultDtoOpgaver?> Get(int id);
    Task<IEnumerable<QueryResultDtoOpgaver>?> GetAll();
    Task<IEnumerable<QueryResultDtoOpgaver>?> GetAllByProjektId(int projektId);
    Task Update(UpdateRequestDtoOpgaver request);
    Task Delete(int id);
}