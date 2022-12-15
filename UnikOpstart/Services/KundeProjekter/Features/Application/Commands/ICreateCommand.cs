namespace UnikOpstart.Services.KundeProjekter.Application.Commands
{
    public interface ICreateCommand<T>
    {
        void Create(T dto);
    }
}