
using UnikOpstart.Services.MedarbejderKompetencer.Application.Commands;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.MedarbejderKomp
{
    public class DeleteCommandMedarbejderKomp : IDeleteCommand<MedarbejderKompEntity>
    {
        private readonly IRepositoryMedarbejderKomp _repository;

        public DeleteCommandMedarbejderKomp(IRepositoryMedarbejderKomp repository)
        {
            _repository = repository;
        }

        void IDeleteCommand<MedarbejderKompEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
