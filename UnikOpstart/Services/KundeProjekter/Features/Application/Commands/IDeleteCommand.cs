namespace UnikOpstart.Services.KundeProjekter.Application.Commands
{
    public interface IDeleteCommand<T>
    {
        void Delete(int id);
    }
}