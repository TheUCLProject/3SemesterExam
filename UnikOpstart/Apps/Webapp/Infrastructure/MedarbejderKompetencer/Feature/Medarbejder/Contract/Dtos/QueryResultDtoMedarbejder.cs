namespace Webapp.Infrastructure.Medarbejder.Contract.Dtos
{
    public class QueryResultDtoMedarbejder
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ProcessRole { get; set; }
        public string? Email { get; set; }
        public int PhoneNr { get; set; }
    }
    
}