using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries.Implementations.Opgave;

public class GetAllQueryOpgave : IGetAllQuery<QueryResultDtoOpgave>
{
    private readonly IRepositoryOpgave _repository;
    public GetAllQueryOpgave(IRepositoryOpgave repository)
    {
        _repository = repository;
    }
    IEnumerable<QueryResultDtoOpgave> IGetAllQuery<QueryResultDtoOpgave>.GetAll()
    {
        return _repository.GetAll();
    }
}