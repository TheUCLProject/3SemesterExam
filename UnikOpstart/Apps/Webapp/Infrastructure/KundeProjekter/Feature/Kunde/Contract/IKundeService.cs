using Webapp.Infrastructure.Kunde.Contract.Dtos;

namespace Webapp.Infrastructure.Kunde.Contract;

public interface IKundeService
{
    Task Create(CreateRequestDtoKunde request);
    Task<QueryResultDtoKunde?> Get(int id);
    Task<IEnumerable<QueryResultDtoKunde>?> GetAll();
    Task Update(UpdateRequestDtoKunde request);
    Task Delete(int id);
}