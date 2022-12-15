
using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.MedarbejderKomp;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.Repositories.Implementations
{
    public class RepositoryMedarbejderKomp : IRepositoryMedarbejderKomp
    {

        private MedarbejderKompetencerContext _db;

        public RepositoryMedarbejderKomp(MedarbejderKompetencerContext db)
        {
            _db = db;
        }

        void IRepositoryMedarbejderKomp.Create(MedarbejderKompEntity entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        void IRepositoryMedarbejderKomp.Delete(int id)
        {
            var dbEntity = _db.MedarbejderKompetencer.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _db.MedarbejderKompetencer.Attach(dbEntity);
            _db.MedarbejderKompetencer.Remove(dbEntity);
            _db.SaveChanges();
        }

        IEnumerable<QueryResultDtoMedarbejderKomp> IRepositoryMedarbejderKomp.GetAllKompetencerByMedarbejderId(int medarbejderId)
        {
            foreach (var entity in _db.MedarbejderKompetencer.AsNoTracking().ToList().Where(x => x.MedarbejderId == medarbejderId))
                yield return new QueryResultDtoMedarbejderKomp
                {
                    Id = entity.Id,
                    MedarbejderId = entity.MedarbejderId,
                    KompetenceId = entity.KompetenceId
                };
        }

        IEnumerable<QueryResultDtoMedarbejderKomp> IRepositoryMedarbejderKomp.GetAllByKompetenceId(int kompetenceId)
        {
            foreach (var entity in _db.MedarbejderKompetencer.AsNoTracking().ToList().Where(x => x.KompetenceId == kompetenceId))
                yield return new QueryResultDtoMedarbejderKomp
                {
                    Id = entity.Id,
                    MedarbejderId = entity.MedarbejderId,
                    KompetenceId = entity.KompetenceId
                };
        }
    }
}
