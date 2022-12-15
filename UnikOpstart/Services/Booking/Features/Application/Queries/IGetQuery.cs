namespace UnikOpstart.Services.Booking.Application.Queries
{
    public interface IGetQuery<T>
    {
        T Get(int id);
    }
}