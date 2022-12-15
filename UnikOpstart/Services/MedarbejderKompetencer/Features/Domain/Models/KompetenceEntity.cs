using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;

namespace UnikOpstart.Services.MedarbejderKompetencer.Domain.Models
{
    public class KompetenceEntity
    {
        public int Id  { get; }
        public string Egenskab { get; private set; }
        public ICollection<MedarbejderKompEntity> Medarbejdere { get; private set; }

        private readonly IDomainServiceKompetence _domainService;

        public KompetenceEntity(IDomainServiceKompetence domainService, string egenskab)
        {
            _domainService = domainService;

            Egenskab = egenskab;
        }

        // For Entity Framework only!
        internal KompetenceEntity()
        {
        }

        public void Update(int Id, string egenskab)
        {   
            Egenskab = egenskab;
        }
    }
}