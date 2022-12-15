
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories
{
    public interface IRepositoryMedarbejderKomp
    {
        void Create(MedarbejderKompEntity entity);

        void Delete(int id);
        IEnumerable<QueryResultDtoMedarbejderKomp> GetAllByKompetenceId(int id);
        IEnumerable<QueryResultDtoMedarbejderKomp> GetAllKompetencerByMedarbejderId(int medarbejderId);
    }
}
