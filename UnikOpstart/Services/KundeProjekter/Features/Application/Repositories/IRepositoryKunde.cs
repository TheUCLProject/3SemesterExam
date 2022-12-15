using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;

namespace UnikOpstart.Services.KundeProjekter.Application.Repositories
{
    public interface IRepositoryKunde
    {
        void Create(KundeEntity entity);
        void Delete(int id);
        QueryResultDtoKunde Get(int id);
        IEnumerable<QueryResultDtoKunde> GetAll();
        void Update(KundeEntity entity);
        KundeEntity Load(int id);
    }
}