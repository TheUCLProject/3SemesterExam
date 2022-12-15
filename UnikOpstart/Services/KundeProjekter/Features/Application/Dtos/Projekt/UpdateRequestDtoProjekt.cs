namespace UnikOpstart.Services.KundeProjekter.Application.Dtos.Projekt
{
    public class UpdateRequestDtoProjekt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string ActiveProcess { get; set; }
        public int Version { get; set; }
    }
}