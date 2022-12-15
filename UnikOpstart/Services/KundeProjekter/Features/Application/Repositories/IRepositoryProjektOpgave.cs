using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;

namespace UnikOpstart.Services.KundeProjekter.Application.Repositories
{
    public interface IRepositoryProjektOpgave
    {
        void Create(ProjektOpgaveEntity entity);
        void Delete(int id);
        IEnumerable<QueryResultDtoProjektOpgave> GetAllOpgaverForProjekt(int projektId);
    }
}