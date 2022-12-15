using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
public interface IRepositoryMedarbejder
{
    void Create(MedarbejderEntity medarbejderEntity);

    void Update(MedarbejderEntity medarbejderEntity);

    void Delete(int id);

    MedarbejderEntity Load(int id);
    IEnumerable<QueryResultDtoMedarbejder> GetAll();
    QueryResultDtoMedarbejder Get(int id);
    IEnumerable<QueryResultDtoMedarbejder> GetAllByKompetenceId(int id);
}
