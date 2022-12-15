using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Opgave;

public class DeleteCommandOpgave : IDeleteCommand<OpgaveEntity>
{
    private readonly IRepositoryOpgave _repository;

    public DeleteCommandOpgave(IRepositoryOpgave repository)
    {
        _repository = repository;
    }

    void IDeleteCommand<OpgaveEntity>.Delete(int id)
    {
        _repository.Delete(id);
    }
}