using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Medarbejder
{
    public class GetQueryMedarbejder : IGetQuery<QueryResultDtoMedarbejder>
    {
        private readonly IRepositoryMedarbejder _repository;
        public GetQueryMedarbejder(IRepositoryMedarbejder repository)
        {
            _repository = repository;
        }
        QueryResultDtoMedarbejder IGetQuery<QueryResultDtoMedarbejder>.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}