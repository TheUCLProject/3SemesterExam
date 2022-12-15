using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories
{
    public interface IRepositoryKompetence
    {
        void Create(KompetenceEntity entity);
        void Update(KompetenceEntity entity);
        void Delete(int id);
        KompetenceEntity Load(int id);
        IEnumerable<QueryResultDtoKompetence> GetAll();
        QueryResultDtoKompetence Get(int id);
        QueryResultDtoKompetence GetByEgenskab(string egenskab);
        IEnumerable<QueryResultDtoKompetence> GetAllByMedarbejderId(int medarbejderId);
    }
}