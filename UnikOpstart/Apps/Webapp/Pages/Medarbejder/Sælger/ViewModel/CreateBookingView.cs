namespace UnikOpstart.Webapp.Pages.Medarbejder.Sælger.ViewModels
{
    public class CreateBookingView
    {
        public int MedarbejderId { get; set; }
        public int OpgaveId { get; set; }
        public int TimeEstimat { get; set; }
        public string StartDato { get; set; }
        public string SlutDato { get; set; }
    }
}