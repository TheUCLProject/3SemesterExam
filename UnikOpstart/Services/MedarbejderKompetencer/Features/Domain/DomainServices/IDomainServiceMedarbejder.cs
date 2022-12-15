namespace UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices
{
    public interface IDomainServiceMedarbejder
    {
        bool AlreadyExists(string name);
        bool MedarbejderExistsInDb(int id);
    }
}