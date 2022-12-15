namespace UnikOpstart.Services.Booking.Application.Commands
{
    public interface IUpdateCommand<T>
    {
        void Update(T Dto);
    }
}