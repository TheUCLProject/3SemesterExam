using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Medarbejder
{
    public class DeleteCommandMedarbejder : IDeleteCommand<MedarbejderEntity>
    {
        private readonly IRepositoryMedarbejder _repository;
        public DeleteCommandMedarbejder(IRepositoryMedarbejder repository)
        {
            _repository = repository;
        }
        void IDeleteCommand<MedarbejderEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}