using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Application.Dtos.Opgave;

namespace UnikOpstart.Services.KundeProjekter.Application.Repositories;

public interface IRepositoryOpgave
{
    void Create(OpgaveEntity entity);
    QueryResultDtoOpgave Get(int id);
    IEnumerable<QueryResultDtoOpgave> GetAll();
    void Update(OpgaveEntity entity);
    OpgaveEntity Load(int id);
    void Delete(int id);
    QueryResultDtoOpgave GetByTitle(string title);
}