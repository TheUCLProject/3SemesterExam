using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Kompetence
{
    public class UpdateCommandKompetence : IUpdateCommand<UpdateRequestDtoKompetence>
    {
        private readonly IRepositoryKompetence _repository;

        public UpdateCommandKompetence(IRepositoryKompetence repository)
        {
            _repository = repository;
        }

        void IUpdateCommand<UpdateRequestDtoKompetence>.Update(UpdateRequestDtoKompetence updateRequestDto)
        {
            // Read
            var model = _repository.Load(updateRequestDto.Id);

            // DoIt
            model.Update(updateRequestDto.MedarbejderId, updateRequestDto.Egenskab);

            // Save
            _repository.Update(model);
        }
    }
}