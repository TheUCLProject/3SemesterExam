namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries
{
    public interface IGetQuery<T>
    {
        T Get(int id);
    }
}