using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;

namespace UnikOpstart.Services.KundeProjekter.Infrastructure.Repositories.Implementations
{
    public class RepositoryKunde : IRepositoryKunde
    {

        private readonly KundeProjekterContext _db;

        public RepositoryKunde(KundeProjekterContext db)
        {
            _db = db;
        }

        void IRepositoryKunde.Create(KundeEntity entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        void IRepositoryKunde.Delete(int id)
        {
            var entity = _db.Kunder.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity == null) throw new Exception("Kunden med det givne id, findes ikke i databasen.");

            _db.Remove(entity);
            _db.SaveChanges();
        }

        QueryResultDtoKunde IRepositoryKunde.Get(int id)
        {
            var dbEntity = _db.Kunder.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (dbEntity == null) throw new ArgumentException("Kunde findes ikke");
            return new QueryResultDtoKunde { Id = dbEntity.Id, Name = dbEntity.Name, Email = dbEntity.Email, TlfNr = dbEntity.TlfNr };
        }

        IEnumerable<QueryResultDtoKunde> IRepositoryKunde.GetAll()
        {
            foreach (var entity in _db.Kunder.AsNoTracking().ToList())
            {
                yield return new QueryResultDtoKunde { Id = entity.Id, Name = entity.Name, Email = entity.Email, TlfNr = entity.TlfNr };
            };
        }

        KundeEntity IRepositoryKunde.Load(int id)
        {
            var dbEntity = _db.Kunder.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (dbEntity == null) throw new ArgumentException("Kunde findes ikke");
            return dbEntity;
        }

        void IRepositoryKunde.Update(KundeEntity entity)
        {
            // Concurrency handling??!!
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}