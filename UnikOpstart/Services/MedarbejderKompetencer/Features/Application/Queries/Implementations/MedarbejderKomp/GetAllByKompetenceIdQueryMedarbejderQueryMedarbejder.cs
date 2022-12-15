using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.MedarbejderKomp
{
    public class GetAllByKompetenceIdQueryMedarbejder : IGetAllByKompetenceIdQueryMedarbejder
    {
        private readonly IRepositoryMedarbejderKomp _repository;

        public GetAllByKompetenceIdQueryMedarbejder(IRepositoryMedarbejderKomp repository)
        {
            _repository = repository;
        }

        IEnumerable<QueryResultDtoMedarbejderKomp> IGetAllByKompetenceIdQueryMedarbejder.GetAllByKompetenceId(int id)
        {
            return _repository.GetAllByKompetenceId(id);
        }
    }
}