namespace UnikOpstart.Services.Booking.Domain.Models
{
    public class BookingEntity
    {
        public int Id { get; }
        public int MedarbejderId { get; private set; }
        public int OpgaveId { get; private set; }
        public string Title { get; private set; }
        public string StartDato { get; private set; }
        public string SlutDato { get; private set; }
        public string Kommentar { get; private set; }

        public BookingEntity(int medarbejderId, int opgaveId, string title, string startDato, string slutDato, string kommentar)
        {
            MedarbejderId = medarbejderId;
            OpgaveId = opgaveId;
            Title = title;
            StartDato = startDato;
            SlutDato = slutDato;
            Kommentar = kommentar;
        }

        public void Update(int opgaveId, string title, string startDato, string slutDato, string kommentar)
        {
            OpgaveId = opgaveId;
            Title = title;
            StartDato = startDato;
            SlutDato = slutDato;
            Kommentar = kommentar;
        }

        // EF Core only!
        internal BookingEntity()
        {
        }
    }   
}