namespace UnikOpstart.Services.KundeProjekter.Application.Commands
{
    public interface IUpdateCommand<T>
    {
        void Update(T Dto);
    }
}