using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries
{
    public interface IGetByEgenskabQueryKompetence
    {
        QueryResultDtoKompetence GetByEgenskab(string egenskab);
    }
}