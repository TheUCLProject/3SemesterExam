using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries
{
    public interface IGetAllByMedarbejderIdQueryKompetence
    {
        IEnumerable<QueryResultDtoMedarbejderKomp> GetAllByMedarbejderId(int id);
    }
}