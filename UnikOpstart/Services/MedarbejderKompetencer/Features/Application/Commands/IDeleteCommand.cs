namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands
{
    public interface IDeleteCommand<T>
    {
        void Delete(int id);
    }
}