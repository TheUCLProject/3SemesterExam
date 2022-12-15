namespace Webapp.Infrastructure.Kompetencer.Contract.Dtos
{
    public class UpdateRequestDtoKompetencer
    {
        public int Id { get; set; }
        public int MedarbejderId { get; set; }
        public string? Egenskab { get; set; }
    }

}