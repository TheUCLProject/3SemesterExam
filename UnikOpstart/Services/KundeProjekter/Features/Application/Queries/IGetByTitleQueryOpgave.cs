using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries
{
    public interface IGetByTitleQueryOpgave
    {
        QueryResultDtoOpgave GetByTitle(string title);
    }
}