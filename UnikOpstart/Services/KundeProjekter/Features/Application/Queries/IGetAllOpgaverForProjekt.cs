using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries
{
    public interface IGetAllOpgaverForProjekt
    {
        IEnumerable<QueryResultDtoProjektOpgave> GetAllOpgaverForProjekt(int projektId);
    }
}
