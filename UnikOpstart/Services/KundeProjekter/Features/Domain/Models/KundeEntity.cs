namespace UnikOpstart.Services.KundeProjekter.Domain.Models
{
    public class KundeEntity
    {
        public int Id { get; }

        public string UserId { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int TlfNr { get; private set; }

        public ICollection<ProjektEntity> Projekter { get; private set; }

        public KundeEntity(string userId, string name, string email, int tlfNr)
        {
            if (!CheckIfValidPhoneNr(tlfNr)) throw new ArgumentException("Tlf Nr er ikke gyldigt");
            if (!CheckIfValidEmail(email)) throw new ArgumentException("Email overholder ikke regler for email");

            UserId = userId;
            Name = name;
            Email = email;
            TlfNr = tlfNr;
        }

        // EF Core only!
        internal KundeEntity()
        {
        }

        // Methods to check if the email and phone number is valid
        private bool CheckIfValidPhoneNr(int phoneNr)
        {
            if (phoneNr < 10000000 || phoneNr > 99999999)
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

        public void Update(string name, string email, int tlfNr)
        {
            if (!CheckIfValidPhoneNr(tlfNr)) throw new ArgumentException("Tlf Nr er ikke gyldigt");
            if (!CheckIfValidEmail(email)) throw new ArgumentException("Email overholder ikke regler for email");

            Name = name;
            Email = email;
            TlfNr = tlfNr;
        }
    }
}