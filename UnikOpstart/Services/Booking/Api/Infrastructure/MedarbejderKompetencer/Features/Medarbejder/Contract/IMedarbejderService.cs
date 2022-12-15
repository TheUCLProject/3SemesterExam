namespace UnikOpstart.Services.Booking.Api.Infrastructure.MedarbejderKompetencer.Features.Medarbejder;

public interface IMedarbejderService
{
    Task<bool> MedarbejderExistsInDb(int id);
}