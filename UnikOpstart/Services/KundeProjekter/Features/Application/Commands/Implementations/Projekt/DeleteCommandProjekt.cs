using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Projekt
{
    public class DeleteCommandProjekt : IDeleteCommand<ProjektEntity>
    {
        private readonly IRepositoryProjekt _repository;
        public DeleteCommandProjekt(IRepositoryProjekt repository)
        {
            _repository = repository;
        }

        void IDeleteCommand<ProjektEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}