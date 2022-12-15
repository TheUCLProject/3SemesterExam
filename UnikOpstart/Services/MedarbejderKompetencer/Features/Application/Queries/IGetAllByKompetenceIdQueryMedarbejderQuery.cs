using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries
{
    public interface IGetAllByKompetenceIdQueryMedarbejder
    {
        IEnumerable<QueryResultDtoMedarbejderKomp> GetAllByKompetenceId(int id);
    }
}