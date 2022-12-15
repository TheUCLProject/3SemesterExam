using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Kompetence
{
    public class GetQueryKompetence : IGetQuery<QueryResultDtoKompetence>
    {
        private readonly IRepositoryKompetence _repository;

        public GetQueryKompetence(IRepositoryKompetence repository)
        {
            _repository = repository;
        }
        QueryResultDtoKompetence IGetQuery<QueryResultDtoKompetence>.Get(int id)
        {
            return _repository.Get(id);
        }
    }   
}