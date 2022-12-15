using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.ProjektOpgave
{
    public class DeleteCommandProjektOpgave : IDeleteCommand<ProjektOpgaveEntity>
    {
        private readonly IRepositoryProjektOpgave _repository;
        public DeleteCommandProjektOpgave(IRepositoryProjektOpgave repository)
        {
            _repository = repository;
        }

        void IDeleteCommand<ProjektOpgaveEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}