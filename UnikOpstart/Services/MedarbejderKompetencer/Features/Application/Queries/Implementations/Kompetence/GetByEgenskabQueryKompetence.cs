using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries.Implementations.Kompetence
{
    public class GetByEgenskabQueryKompetence : IGetByEgenskabQueryKompetence
    {
        private readonly IRepositoryKompetence _repository;

        public GetByEgenskabQueryKompetence(IRepositoryKompetence repository)
        {
            _repository = repository;
        }
        QueryResultDtoKompetence IGetByEgenskabQueryKompetence.GetByEgenskab(string egenskab)
        {
            return _repository.GetByEgenskab(egenskab);
        }
    }
}