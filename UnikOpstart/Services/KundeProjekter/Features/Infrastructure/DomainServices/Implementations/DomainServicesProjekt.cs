using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext;

namespace UnikOpstart.Services.KundeProjekter.Infrastructure.DomainServices.Implementations
{
    public class DomainServiceProjekt : IDomainServiceProjekt
    {
        private readonly KundeProjekterContext _db;

        public DomainServiceProjekt(KundeProjekterContext db)
        {
            _db = db;
        }

        bool IDomainServiceProjekt.KundeIdIsValid(int id)
        {
            return _db.Kunder.Any(x => x.Id == id);
        }
    }
}