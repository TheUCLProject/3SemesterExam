using UnikOpstart.Services.KundeProjekter.Application.Dtos;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries
{
    public interface IGetQuery<T>
    {
        T Get(int id);
    }
}