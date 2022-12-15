using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries
{
    public interface IGetAllProjekterByKundeId
    {
        IEnumerable<QueryResultDtoProjekt> GetAllProjekterByKundeId(int kundeId);
    }
}
