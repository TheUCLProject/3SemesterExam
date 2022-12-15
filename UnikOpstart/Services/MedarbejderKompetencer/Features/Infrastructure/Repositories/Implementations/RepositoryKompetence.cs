using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.Repositories.Implementations
{
    public class RepositoryKompetence : IRepositoryKompetence
    {
        private readonly MedarbejderKompetencerContext _db;
        
        public RepositoryKompetence(MedarbejderKompetencerContext db)
        {
            _db = db;
        }

        void IRepositoryKompetence.Create(KompetenceEntity entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        void IRepositoryKompetence.Update(KompetenceEntity entity)
        {
            // Concurrency handling -- Add here!!!

            _db.Update(entity);
            _db.SaveChanges();
        }

        void IRepositoryKompetence.Delete(int id)
        {
            var dbEntity = _db.KompetenceEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _db.KompetenceEntities.Attach(dbEntity);
            _db.KompetenceEntities.Remove(dbEntity);
            _db.SaveChanges();
        }

        KompetenceEntity IRepositoryKompetence.Load(int id)
        {
            var dbEntity = _db.KompetenceEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(dbEntity == null) throw new Exception("Kompetence findes ikke i database");

            return dbEntity;
        }

        // Returns predifined list of KompetenceEntities --> where MedarbejderId = null
        IEnumerable<QueryResultDtoKompetence> IRepositoryKompetence.GetAll()
        {
            foreach (var dbEntity in _db.KompetenceEntities.AsNoTracking())
            {
                yield return new QueryResultDtoKompetence
                {
                    Id = dbEntity.Id,
                    Egenskab = dbEntity.Egenskab
                };
            }
        }

        // Returns KompetenceEntities List for a specific Medarbejder.
        IEnumerable<QueryResultDtoKompetence> IRepositoryKompetence.GetAllByMedarbejderId(int medarbejderId)
        {
            /*
            foreach (var dbEntity in _db.KompetenceEntities.AsNoTracking().Where(x => x.MedarbejderId == medarbejderId))
            {
                yield return new QueryResultDtoKompetence
                {
                    Id = dbEntity.Id,
                    MedarbejderId = dbEntity.MedarbejderId,
                    Egenskab = dbEntity.Egenskab
                };
            }*/

            throw new ArgumentException("Is not implemented - not needed.");
        }

        QueryResultDtoKompetence IRepositoryKompetence.Get(int id)
        {
            var dbEntity = _db.KompetenceEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (dbEntity == null) throw new Exception("Kompetence findes ikke i databasen");

            return new QueryResultDtoKompetence
            {
                Id = dbEntity.Id,
                Egenskab = dbEntity.Egenskab
            };
        }

        public QueryResultDtoKompetence GetByEgenskab(string egenskab)
        {
            var dbEntity = _db.KompetenceEntities.AsNoTracking().FirstOrDefault(x => x.Egenskab == egenskab);
            if (dbEntity == null) throw new Exception("Kompetence findes ikke i databasen");

            return new QueryResultDtoKompetence
            {
                Id = dbEntity.Id,
                Egenskab = dbEntity.Egenskab
            };
        }
    }
}