namespace UnikOpstart.Services.KundeProjekter.Domain.Models
{
    public class ProjektOpgaveEntity
    {
        public int Id { get; set; }
        public int ProjektId { get; set; }
        public ProjektEntity Projekt { get; set; }
        public int OpgaveId { get; set; }
        public OpgaveEntity Opgave { get; set; }

        public ProjektOpgaveEntity(int projektId, int opgaveId)
        {
            //Add domain service checks here.
            ProjektId = projektId;
            OpgaveId = opgaveId;
        }
    }
}
