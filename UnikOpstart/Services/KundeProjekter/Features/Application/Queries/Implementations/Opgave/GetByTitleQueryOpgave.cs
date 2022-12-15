using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Opgave
{
    public class GetByTitleQueryOpgave : IGetByTitleQueryOpgave
    {
        private readonly IRepositoryOpgave _repository;

        public GetByTitleQueryOpgave(IRepositoryOpgave repository)
        {
            _repository = repository;
        }

        QueryResultDtoOpgave IGetByTitleQueryOpgave.GetByTitle(string title)
        {
            return _repository.GetByTitle(title);
        }
    }
}