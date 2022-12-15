using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;

namespace UnikOpstart.Services.KundeProjekter.Infrastructure.DomainServices.Implementations
{
    public class DomainServiceOpgave : IDomainServiceOpgave
    {
        private readonly KundeProjekterContext _db;

        public DomainServiceOpgave(KundeProjekterContext db)
        {
            _db = db;
        }

        bool IDomainServiceOpgave.ProjektIdExistsInDb(int id)
        {
            return _db.Projekter.Any(x => x.Id == id);
        }
    }   
}