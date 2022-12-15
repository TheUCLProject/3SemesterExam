namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Medarbejder
{
    public class UpdateRequestDtoMedarbejder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProcessRole { get; set; }
        public int PhoneNr { get; set; }
        public string Email { get; set; }
    //    public int Version { get; set; }
    }
}