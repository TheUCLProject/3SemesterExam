namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence
{
    public class CreateRequestDtoKompetence
    {
        int Id { get; set; }
        public int MedarbejderId { get; set; }
        public string Egenskab { get; set; }
    }
}