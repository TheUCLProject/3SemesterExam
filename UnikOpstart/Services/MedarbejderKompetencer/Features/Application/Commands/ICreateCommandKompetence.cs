using UnikOpstart.Services.MedarbejderKompetencer.Application.Dtos.Kompetence;

namespace UnikOpstart.Services.MedarbejderKompetencer.Application.Commands
{
    public interface ICreateCommandKompetence
    {
        int Create(CreateRequestDtoKompetence dto);
    }
}