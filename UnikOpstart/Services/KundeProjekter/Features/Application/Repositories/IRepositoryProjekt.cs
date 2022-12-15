using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;

namespace UnikOpstart.Services.KundeProjekter.Application.Repositories
{
    public interface IRepositoryProjekt
    {
        void Create(ProjektEntity projektEntity);
        void Update(ProjektEntity projektEntity);
        void Delete(int id);
        ProjektEntity Load(int id);
        QueryResultDtoProjekt Get(int id);
        IEnumerable<QueryResultDtoProjekt> GetAll();
        IEnumerable<QueryResultDtoProjekt> GetAllProjekterByKundeId(int kundeId);


    }
}