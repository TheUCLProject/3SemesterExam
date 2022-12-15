namespace Webapp.Infrastructure.Medarbejder.Contract.Dtos
{
    public class CreateRequestDtoMedarbejder
    {
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? ProcessRole { get; set; }
        public string? Email { get; set; }
        public int PhoneNr { get; set; }
    }
    
}