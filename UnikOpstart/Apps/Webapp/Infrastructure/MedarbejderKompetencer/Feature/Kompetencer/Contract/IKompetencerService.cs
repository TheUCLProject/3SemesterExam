using UnikOpstart.Webapp.Infrastructure.MedarbejderKompetencer.Feature.Kompetencer.Contract.Dtos;
using Webapp.Infrastructure.Kompetencer.Contract.Dtos;

namespace Webapp.Infrastructure.Kompetencer.Contract
{
    public interface IKompetencerService
    {
        Task Create(CreateRequestDtoKompetencer request);
        Task Update(UpdateRequestDtoKompetencer request);
        Task Delete(int id);
        Task<QueryResultDtoKompetencer?> Get(int id);
        Task<IEnumerable<QueryResultDtoKompetencer>?> GetAll();
        Task<IEnumerable<QueryResultDtoKompetencer>?> GetAllByMedarbejderId(int medarbejderId);
        Task Add(CreateRequestDtoMedarbejderKompetence requestDtoMedarbejderKompetence);
    }
}