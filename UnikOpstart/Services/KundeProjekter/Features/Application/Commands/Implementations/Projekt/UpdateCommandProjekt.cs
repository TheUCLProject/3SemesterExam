using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Projekt
{
    public class UpdateCommandProjekt : IUpdateCommand<UpdateRequestDtoProjekt>
    {
        private readonly IRepositoryProjekt _repository;
        public UpdateCommandProjekt(IRepositoryProjekt repository)
        {
            _repository = repository;
        }

        void IUpdateCommand<UpdateRequestDtoProjekt>.Update(UpdateRequestDtoProjekt requestDto)
        {
            //REVISIT THIS.
            var request = _repository.Load(requestDto.Id);

            request.Update(requestDto.Name, 
                           requestDto.ContactPerson, 
                           requestDto.ActiveProcess,
                           requestDto.Version);

            _repository.Update(request);
        }
    }
}