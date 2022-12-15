namespace Webapp.Infrastructure.Projekt.Contract.Dtos
{
    public class QueryResultDtoProjekt
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public string? Name { get; set; }
        public string? ContactPerson { get; set; }
        public string? ActiveProcess { get; set; }
        public int Version { get; set; }
    }
    
}