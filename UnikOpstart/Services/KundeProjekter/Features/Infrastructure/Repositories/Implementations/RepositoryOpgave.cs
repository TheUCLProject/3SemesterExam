using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;

namespace UnikOpstart.Services.KundeProjekter.Infrastructure.Repositories.Implementations;

public class RepositoryOpgave : IRepositoryOpgave
{
    private readonly KundeProjekterContext _db;

    public RepositoryOpgave(KundeProjekterContext db)
    {
        _db = db;
    }

    void IRepositoryOpgave.Create(OpgaveEntity entity)
    {
        _db.Add(entity);
        _db.SaveChanges();
    }

    QueryResultDtoOpgave IRepositoryOpgave.Get(int id)
    {
        var dbEntity = _db.Opgaver.AsNoTracking().FirstOrDefault(x => x.Id == id);

        if (dbEntity == null) throw new Exception("Projektet med det givne id, findes ikke i databasen.");

        return new QueryResultDtoOpgave
        {
            Id = dbEntity.Id,
            Title = dbEntity.Title,
            Process_Kategori = dbEntity.Process_Kategori,
            KompetenceId = dbEntity.KompetenceId,
            TimeEstimat = dbEntity.TimeEstimat,
            Kommentar = dbEntity.Kommentar
        };

    }

    IEnumerable<QueryResultDtoOpgave> IRepositoryOpgave.GetAll()
    {
        foreach (var dbEntity in _db.Opgaver.AsNoTracking().ToList())

            yield return new QueryResultDtoOpgave
            {
                Id = dbEntity.Id,
                Title = dbEntity.Title,
                Process_Kategori = dbEntity.Process_Kategori,
                KompetenceId = dbEntity.KompetenceId,
                TimeEstimat = dbEntity.TimeEstimat,
                Kommentar = dbEntity.Kommentar
            };
    }

    void IRepositoryOpgave.Delete(int id)
    {
        var dbEntity = _db.Opgaver.AsNoTracking().FirstOrDefault(x => x.Id == id);
        _db.Opgaver.Attach(dbEntity);
        _db.Opgaver.Remove(dbEntity);
        _db.SaveChanges();
    }

    void IRepositoryOpgave.Update(OpgaveEntity entity)
    {
        // Concurrency handling??!!
        _db.Update(entity);
        _db.SaveChanges();
    }

    OpgaveEntity IRepositoryOpgave.Load(int id)
    {
        var dbEntity = _db.Opgaver.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (dbEntity == null) throw new Exception("Kompetance findes ikke i database");

        return dbEntity;
    }

    public QueryResultDtoOpgave GetByTitle(string title)
    {
        var dbEntity = _db.Opgaver.AsNoTracking().FirstOrDefault(x => x.Title == title);

        if (dbEntity == null) throw new Exception("Opgave med den givne title, findes ikke i databasen.");

        return new QueryResultDtoOpgave
        {
            Id = dbEntity.Id,
            Title = dbEntity.Title,
            Process_Kategori = dbEntity.Process_Kategori,
            KompetenceId = dbEntity.KompetenceId,
            TimeEstimat = dbEntity.TimeEstimat,
            Kommentar = dbEntity.Kommentar
        };
    }
}