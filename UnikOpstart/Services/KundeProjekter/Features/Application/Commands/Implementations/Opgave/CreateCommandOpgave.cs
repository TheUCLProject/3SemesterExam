using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;



namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Opgave;

public class CreateCommandOpgave : ICreateCommand<CreateRequestDtoOpgave>
{
    private readonly IRepositoryOpgave _repository;
    private readonly IDomainServiceOpgave _domainService;
    public CreateCommandOpgave(IRepositoryOpgave repository, IDomainServiceOpgave domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    void ICreateCommand<CreateRequestDtoOpgave>.Create(CreateRequestDtoOpgave createRequestDtoOpgave)
    {
        var OpgaveEntity = new OpgaveEntity(_domainService,
                                            createRequestDtoOpgave.Title,
                                            createRequestDtoOpgave.Process_Kategori,
                                            createRequestDtoOpgave.KompetenceId,
                                            createRequestDtoOpgave.TimeEstimat,
                                            createRequestDtoOpgave.Kommentar
                                            );
        _repository.Create(OpgaveEntity);
    }
}