namespace UnikOpstart.Services.Booking.Application.Commands
{
    public interface IDeleteCommand<T>
    {
        void Delete(int id);
    }
}