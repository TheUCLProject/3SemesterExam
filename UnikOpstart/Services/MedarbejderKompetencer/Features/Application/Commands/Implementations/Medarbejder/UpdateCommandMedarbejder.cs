using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Medarbejder
{
    public class UpdateCommandMedarbejder : IUpdateCommand<UpdateRequestDtoMedarbejder>
    {
        private readonly IRepositoryMedarbejder _repository;
        public UpdateCommandMedarbejder(IRepositoryMedarbejder repository)
        {
          _repository = repository;
        }
        void IUpdateCommand<UpdateRequestDtoMedarbejder>.Update(UpdateRequestDtoMedarbejder updateRequestDto)
        {
            // Read
            var model = _repository.Load(updateRequestDto.Id);

            // DoIt
            model.Update(updateRequestDto.Name, updateRequestDto.ProcessRole, updateRequestDto.PhoneNr, updateRequestDto.Email); //Removed updateRequestDto.Version!

            // Save
            _repository.Update(model);
        }

    }
}