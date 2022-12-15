using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.ProjektOpgave;
using UnikOpstart.Services.KundeProjekter.Application.Repositories;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;

namespace UnikOpstart.Services.KundeProjekter.Infrastructure.Repositories.Implementations
{
    public class RepositoryProjektOpgave : IRepositoryProjektOpgave
    {

        private readonly KundeProjekterContext _db;

        public RepositoryProjektOpgave(KundeProjekterContext db)
        {
            _db = db;
        }

        void IRepositoryProjektOpgave.Create(ProjektOpgaveEntity entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        void IRepositoryProjektOpgave.Delete(int id)
        {
            var dbEntity = _db.ProjektOpgaver.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _db.ProjektOpgaver.Attach(dbEntity);
            _db.ProjektOpgaver.Remove(dbEntity);
            _db.SaveChanges();
        }

        IEnumerable<QueryResultDtoProjektOpgave> IRepositoryProjektOpgave.GetAllOpgaverForProjekt(int projektId)
        {
            var dbEntities = _db.ProjektOpgaver.AsNoTracking().Where(x => x.ProjektId == projektId).ToList();

            foreach (var enity in dbEntities)
            {
                yield return new QueryResultDtoProjektOpgave { Id = enity.Id, OpgaveId = enity.OpgaveId, ProjektId = enity.ProjektId };
            }
        }
    }
}