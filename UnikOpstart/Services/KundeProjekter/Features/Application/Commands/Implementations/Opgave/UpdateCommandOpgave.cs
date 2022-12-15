using UnikOpstart.Services.KundeProjekter.Application.Repositories;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Opgave;

public class UpdateCommandOpgave : IUpdateCommand<UpdateRequestDtoOpgave>
{
    private readonly IRepositoryOpgave _repository;

    public UpdateCommandOpgave(IRepositoryOpgave repository)
    {
        _repository = repository;
    }

    void IUpdateCommand<UpdateRequestDtoOpgave>.Update(UpdateRequestDtoOpgave updateRequestDto)
    {
        // Read
        var model = _repository.Load(updateRequestDto.Id);

        // DoIt
        model.Update(updateRequestDto.Title, 
                     updateRequestDto.Process_Kategori, 
                     updateRequestDto.KompetenceId, 
                     updateRequestDto.TimeEstimat, 
                     updateRequestDto.Kommentar);

        // Save
        _repository.Update(model);
    }
}