using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Opgave;

public class GetQueryOpgave : IGetQuery<QueryResultDtoOpgave>
{

    private readonly IRepositoryOpgave _repository;
    public GetQueryOpgave(IRepositoryOpgave repository)
    {
        _repository = repository;
    }
    QueryResultDtoOpgave IGetQuery<QueryResultDtoOpgave>.Get(int id)
    {
        return _repository.Get(id);
    }
}