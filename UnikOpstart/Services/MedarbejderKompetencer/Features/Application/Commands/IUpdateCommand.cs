using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands
{
    public interface IUpdateCommand<T>
    {
        void Update(T Dto);
    }
}