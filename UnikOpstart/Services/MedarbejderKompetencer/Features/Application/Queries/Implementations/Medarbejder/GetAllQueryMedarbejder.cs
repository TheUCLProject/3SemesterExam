using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Medarbejder
{
    public class GetAllQueryMedarbejder : IGetAllQuery<QueryResultDtoMedarbejder>
    {
        private readonly IRepositoryMedarbejder _repositoryMedarbejder;

        public GetAllQueryMedarbejder(IRepositoryMedarbejder repositoryMedarbejder)
        {
            _repositoryMedarbejder = repositoryMedarbejder;
        }

        IEnumerable<QueryResultDtoMedarbejder> IGetAllQuery<QueryResultDtoMedarbejder>.GetAll()
        {
            return _repositoryMedarbejder.GetAll();
        }
    }
}