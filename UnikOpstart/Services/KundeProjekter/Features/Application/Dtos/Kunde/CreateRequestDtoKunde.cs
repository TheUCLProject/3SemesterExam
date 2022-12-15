namespace UnikOpstart.Services.KundeProjekter.Application.Dtos.Kunde
{
    public class CreateRequestDtoKunde
    {
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int TlfNr { get; set; }
    }
}