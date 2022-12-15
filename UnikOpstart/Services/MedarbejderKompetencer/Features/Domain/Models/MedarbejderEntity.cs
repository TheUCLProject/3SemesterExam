using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
using System.ComponentModel.DataAnnotations;

namespace UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
 public class MedarbejderEntity
{
	public int Id { get; }

    public string UserId { get; set; }

    public string Name { get; private set; }

	public string ProcessRole { get; private set; }

	public int PhoneNr { get; private set; }

	public string Email { get; private set; }

	public ICollection<MedarbejderKompEntity> Kompetencer { get; set; }

	/*[Required]
	[Timestamp]
	public int Version { get; set; } //Optimistic Concurrency attribute*/

	private readonly IDomainServiceMedarbejder _domainService;

	public MedarbejderEntity(IDomainServiceMedarbejder domainService, string userId, string name, string processRole, int phoneNr, string email)
	{
		// Performs validation here 	
		if (!CheckIfValidProcessRole(processRole)) throw new ArgumentException("Process Role er ikke gyldig");
		if (!CheckIfValidPhoneNr(phoneNr)) throw new ArgumentException("Tlf Nr er ikke gyldigt");
		if (!CheckIfValidEmail(email)) throw new ArgumentException("Email overholder ikke regler for email");

		_domainService = domainService;

		if(_domainService.AlreadyExists(name))
		{
			throw new ArgumentException("Medarbejder findes allerede i database!");
		}

		UserId = userId;
		Name = name;
		ProcessRole = processRole;
		PhoneNr = phoneNr;
		Email = email;
	}

	// For Entity Framework only!
    internal MedarbejderEntity()
    {
    }

	public void Update(string name, string processRole, int phoneNr, string email) //REMOVED int VERSION IN UPDATE!!!
	{
        if (!CheckIfValidProcessRole(processRole)) throw new ArgumentException("Process Role er ikke gyldig");
        if (!CheckIfValidPhoneNr(phoneNr)) throw new ArgumentException("Tlf Nr er ikke gyldigt");
        if (!CheckIfValidEmail(email)) throw new ArgumentException("Email overholder ikke regler for email");

        Name = name;
		ProcessRole = processRole;
		PhoneNr = phoneNr;
		Email = email;
	}

	private bool CheckIfValidPhoneNr(int phoneNr)
	{
		if (phoneNr < 10000000 || phoneNr > 99999999 )
		{
			return false;
		}
		return true;
	}

	private bool CheckIfValidEmail(string email)
	{
		if (!email.Contains("@") || !email.Contains("."))
		{
			return false;
		}

		if (email.First() == '@' || email.First() == '.')
		{
			return false;
		}

		if (email.Last() == '@' || email.Last() == '.')
		{
			return false;
		}
		
		return true;
	}

	private bool CheckIfValidProcessRole(string processRole)
	{
		if (processRole != "Sælger" && processRole != "Tekniker" && processRole != "Konverter" && processRole != "Konsulent")
		{
			return false;
		}
		return true;
	}
}
