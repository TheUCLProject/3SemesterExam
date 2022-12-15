using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Kompetence
{
    public class GetAllQueryKompetence : IGetAllQuery<QueryResultDtoKompetence>
    {
        private readonly IRepositoryKompetence _repository;

        public GetAllQueryKompetence(IRepositoryKompetence repository)
        {
            _repository = repository;
        }
        IEnumerable<QueryResultDtoKompetence> IGetAllQuery<QueryResultDtoKompetence>.GetAll()
        {
            return _repository.GetAll();
        }
    }
}