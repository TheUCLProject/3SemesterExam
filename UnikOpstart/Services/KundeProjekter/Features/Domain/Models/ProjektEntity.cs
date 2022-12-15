using System.ComponentModel.DataAnnotations;
using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;

namespace UnikOpstart.Services.KundeProjekter.Domain.Models
{
    public class ProjektEntity
    {
        public int Id { get; }
        public KundeEntity Kunde { get; private set; }
        public int KundeId { get; private set; }
        public string Name { get; private set; }
        public string ContactPerson { get; private set; }
        public string ActiveProcess { get; private set; }

        [Timestamp]
        public int Version { get; private set; }

        public ICollection<ProjektOpgaveEntity> Opgaver { get; private set; }

        private readonly IDomainServiceProjekt _domainService;

        public ProjektEntity(IDomainServiceProjekt domainServiceProjekt, int kundeId, string name, string contactPerson, string activeProcess, int version)
        {
            _domainService = domainServiceProjekt;

            if(!_domainService.KundeIdIsValid(kundeId)) throw new ArgumentException("Kunde findes ikke i database");

            Name = name;
            KundeId = kundeId;
            ContactPerson = contactPerson;
            ActiveProcess = activeProcess;
            Version = version;
        }

        internal ProjektEntity()
        {

        }

        public void Update(string name, string contactPerson, string activeProcess, int version)
        {
            Name = name;
            ContactPerson = contactPerson;
            ActiveProcess = activeProcess;
            Version = version;
        }
    }
}