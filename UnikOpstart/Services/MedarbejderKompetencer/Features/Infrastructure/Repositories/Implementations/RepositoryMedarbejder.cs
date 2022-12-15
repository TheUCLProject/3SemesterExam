using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder;
using UnikOpstart.Services.MedarbejderKompetencer.Application.Repositories;
using UnikOpstart.Services.MedarbejderKompetencer.Crosscut.TransactionHandling;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;

namespace UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.Repositories.Implementations;

public class RepositoryMedarbejder : IRepositoryMedarbejder
{
    private readonly MedarbejderKompetencerContext _db;
    private readonly IUnitOfWork _uow;

    public RepositoryMedarbejder(MedarbejderKompetencerContext db, IUnitOfWork uow)
    {
        _db = db;
        _uow = uow;
    }

    void IRepositoryMedarbejder.Create(MedarbejderEntity entity)
    {
    /*    try
        {
            _uow.BeginTransaction(IsolationLevel.ReadUncommitted);
    */
            _db.Add(entity);
            _db.SaveChanges();
    /*
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }
    */
    }

    void IRepositoryMedarbejder.Update(MedarbejderEntity entity)
    {
        /*
        try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);
        */
            _db.Update(entity);
            _db.SaveChanges();
        /*
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }
        */
    }

    QueryResultDtoMedarbejder IRepositoryMedarbejder.Get(int id)
    {
        var dbEntity = _db.MedarbejderEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (dbEntity == null) throw new Exception("Unik Medabejder findes ikke i databasen");

        return new QueryResultDtoMedarbejder
        {
            Id = dbEntity.Id,
            Name = dbEntity.Name,
            ProcessRole = dbEntity.ProcessRole,
            PhoneNr = dbEntity.PhoneNr,
            Email = dbEntity.Email,
            //Version = dbEntity.Version
        };
    }
    IEnumerable<QueryResultDtoMedarbejder> IRepositoryMedarbejder.GetAll()
    {
        foreach (var entity in _db.MedarbejderEntities.AsNoTracking().ToList())
        {
            yield return new QueryResultDtoMedarbejder
            {
                Id = entity.Id,
                Name = entity.Name,
                ProcessRole = entity.ProcessRole,
                PhoneNr = entity.PhoneNr,
                Email = entity.Email,
                //Version = entity.Version
            };
        };
    }

    void IRepositoryMedarbejder.Delete(int id)
    {
        /*try
        {
            _uow.BeginTransaction(IsolationLevel.Serializable);
        */
            var dbEntity = _db.MedarbejderEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _db.MedarbejderEntities.Attach(dbEntity);
            _db.MedarbejderEntities.Remove(dbEntity);
            _db.SaveChanges();
        /*
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }
        */
    }

    MedarbejderEntity IRepositoryMedarbejder.Load(int id)
    {
        var dbEntity = _db.MedarbejderEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (dbEntity == null) throw new Exception("Medarbejder findes ikke i database");

        return dbEntity;
    }

    public IEnumerable<QueryResultDtoMedarbejder> GetAllByKompetenceId(int id)
    {
        var dbEntities = _db.MedarbejderKompetencer.AsNoTracking().Where(x => x.KompetenceId == id).ToList();

        foreach (var enity in dbEntities)
        {
            foreach (var entity in _db.MedarbejderEntities.AsNoTracking().Where(x => x.Id == enity.MedarbejderId).ToList())
            {
                yield return new QueryResultDtoMedarbejder
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ProcessRole = entity.ProcessRole,
                    PhoneNr = entity.PhoneNr,
                    Email = entity.Email,
                    //Version = entity.Version
                };
            }
        }
    }
}