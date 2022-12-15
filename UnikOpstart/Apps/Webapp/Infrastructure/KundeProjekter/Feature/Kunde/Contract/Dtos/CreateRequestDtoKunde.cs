namespace Webapp.Infrastructure.Kunde.Contract.Dtos;

public class CreateRequestDtoKunde
{
    public string? UserId { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int TlfNr { get; set; }
}