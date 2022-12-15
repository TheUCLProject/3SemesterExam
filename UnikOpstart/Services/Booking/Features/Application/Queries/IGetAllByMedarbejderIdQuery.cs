namespace UnikOpstart.Services.Booking.Application.Queries
{
    public interface IGetAllByMedarbejderIdQuery<T>
    {
        IEnumerable<T> GetAllByMedarbejderId(int medarbejderId);
    }
}