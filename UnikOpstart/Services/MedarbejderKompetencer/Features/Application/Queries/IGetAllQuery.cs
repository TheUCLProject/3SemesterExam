namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Queries
{
    public interface IGetAllQuery<T>
    {
        IEnumerable<T> GetAll();
    }
}