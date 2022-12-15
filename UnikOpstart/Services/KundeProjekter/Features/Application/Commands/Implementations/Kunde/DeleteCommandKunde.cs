using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;

namespace UnikOpstart.Services.KundeProjekter.Application.Commands.Implementations.Kunde
{
    public class DeleteCommandKunde : IDeleteCommand<KundeEntity>
    {
        private readonly IRepositoryKunde _repository;

        public DeleteCommandKunde(IRepositoryKunde repository)
        {
            _repository = repository;
        }

        void IDeleteCommand<KundeEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}