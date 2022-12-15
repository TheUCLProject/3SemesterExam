
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;

namespace UnikOpstart.Services.MedarbejderKompetencer.Domain.Models
{
    public class MedarbejderKompEntity
    {
        public int Id { get; set; }

        public int MedarbejderId { get; set; }
        public MedarbejderEntity Medarbejder { get; set; }

        public int KompetenceId { get; set; }
        public KompetenceEntity Kompetence { get; set; }

        public MedarbejderKompEntity(int medarbejderId, int kompetenceId)
        {
            //domain service checks?
            MedarbejderId = medarbejderId;
            KompetenceId = kompetenceId;
        }
    }
}
