using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.ProjektOpgave;

public class CreateCommandProjektOpgave : ICreateCommand<CreateRequestDtoProjektOpgave>
{
    private readonly IRepositoryProjektOpgave _repository;

    public CreateCommandProjektOpgave(IRepositoryProjektOpgave repository)
    {
        _repository = repository;
    }

    void ICreateCommand<CreateRequestDtoProjektOpgave>.Create(CreateRequestDtoProjektOpgave dto)
    {
        var entity = new ProjektOpgaveEntity(dto.ProjektId, dto.OpgaveId);

        _repository.Create(entity);
    }
}