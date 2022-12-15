using UnikOpstart.Services.KundeProjekter.Application.Dtos;

namespace UnikOpstart.Services.KundeProjekter.Application.Queries
{
    public interface IGetAllQuery<T>
    {
        IEnumerable<T> GetAll();
    }
}