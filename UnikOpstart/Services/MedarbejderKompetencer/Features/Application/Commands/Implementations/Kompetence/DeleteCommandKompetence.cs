using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands.Implementations.Kompetence
{
    public class DeleteCommandKompetence : IDeleteCommand<KompetenceEntity>
    {
        private readonly IRepositoryKompetence _repository;

        public DeleteCommandKompetence(IRepositoryKompetence repository)
        {
            _repository = repository;
        }

        void IDeleteCommand<KompetenceEntity>.Delete(int id)
        {
            _repository.Delete(id);
        }
    }   
}