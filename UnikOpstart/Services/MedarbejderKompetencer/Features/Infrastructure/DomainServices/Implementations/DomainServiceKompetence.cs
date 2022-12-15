using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;

namespace UnikOpstart.Services.MedarbejderKompetencer.Infrastructure.DomainServices.Implementations
{
    public class DomainServiceKompetence : IDomainServiceKompetence
    {
        private readonly MedarbejderKompetencerContext _db;

        public DomainServiceKompetence(MedarbejderKompetencerContext db)
        {
            _db = db;
        }

        bool IDomainServiceKompetence.ValidMedarbejderId(int medarbejderId)
        {
            if(_db.MedarbejderEntities.Any(x => x.Id == medarbejderId))
            {
                return true;
            }
            return false;
        }
    }
}