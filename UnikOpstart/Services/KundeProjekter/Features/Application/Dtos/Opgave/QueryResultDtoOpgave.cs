namespace UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;

public class QueryResultDtoOpgave
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Process_Kategori { get; set; }
    public int KompetenceId { get; set; }
    public int TimeEstimat { get; set; }
    public string? Kommentar { get; set; }
}