using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;

namespace UnikOpstart.Services.KundeProjekter.Infrastructure.Repositories.Implementations
{
    public class RepositoryProjekt : IRepositoryProjekt
    {

        private readonly KundeProjekterContext _db;

        public RepositoryProjekt(KundeProjekterContext db)
        {
            _db = db;
        }

        void IRepositoryProjekt.Create(ProjektEntity entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        void IRepositoryProjekt.Update(ProjektEntity entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }

        void IRepositoryProjekt.Delete(int id)
        {
            var entity = _db.Projekter.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new Exception("Projektet med det givne id, findes ikke i databasen.");

            _db.Remove(entity);
            _db.SaveChanges();
        }

        ProjektEntity IRepositoryProjekt.Load(int id)
        {
            var entity = _db.Projekter.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity == null) throw new ArgumentException("Projekt findes ikke");
            return entity;
        }

        QueryResultDtoProjekt IRepositoryProjekt.Get(int id)
        {
            var dbEntity = _db.Projekter.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (dbEntity == null) 
                throw new Exception("Projektet med det givne id, findes ikke i databasen.");

            return new QueryResultDtoProjekt
            {
                Id = dbEntity.Id,
                KundeId = dbEntity.KundeId,
                Name = dbEntity.Name,
                ContactPerson = dbEntity.ContactPerson,
                ActiveProcess = dbEntity.ActiveProcess
            };

        }

        IEnumerable<QueryResultDtoProjekt> IRepositoryProjekt.GetAll()
        {
            foreach (var entity in _db.Projekter.AsNoTracking().ToList())
                yield return new QueryResultDtoProjekt
                { 
                    Id = entity.Id,
                    KundeId = entity.KundeId,
                    Name = entity.Name, 
                    ContactPerson = entity.ContactPerson, 
                    ActiveProcess = entity.ActiveProcess,
                    Version = entity.Version,
                };
        }

        IEnumerable<QueryResultDtoProjekt> IRepositoryProjekt.GetAllProjekterByKundeId(int kundeId)
        {
            foreach (var entity in _db.Projekter.AsNoTracking().ToList().Where(x => x.KundeId == kundeId))
                yield return new QueryResultDtoProjekt
                {
                    Id = entity.Id,
                    KundeId = entity.KundeId,
                    Name = entity.Name,
                    ContactPerson = entity.ContactPerson,
                    ActiveProcess = entity.ActiveProcess
                };
        }
    }
}