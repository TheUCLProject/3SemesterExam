using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands
{
    public interface ICreateCommand<T>
    {
        void Create(T dto);
    }
}