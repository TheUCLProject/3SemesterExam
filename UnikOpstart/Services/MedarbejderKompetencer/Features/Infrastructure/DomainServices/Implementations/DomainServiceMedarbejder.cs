using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;

namespace UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.DomainServices.Implementations
{
    public class DomainServiceMedarbejder : IDomainServiceMedarbejder
    {
        private readonly MedarbejderKompetencerContext _db;

        public DomainServiceMedarbejder(MedarbejderKompetencerContext db)
        {
            _db = db;
        }

        public bool MedarbejderExistsInDb(int id)
        {
            if(_db.MedarbejderEntities.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        bool IDomainServiceMedarbejder.AlreadyExists(string name)
        {
            if(_db.MedarbejderEntities.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}