namespace UnikOpstart.Services.Booking.Application.Commands
{
    public interface ICreateCommand<T>
    {
        void Create(T dto);
    }
}