using UnikOpstart.Services.KundeProjekter.Domain.DomainServices;

namespace UnikOpstart.Services.KundeProjekter.Domain.Models;
public class OpgaveEntity
{
    public int Id { get; }
    public int KompetenceId { get; private set; }
    public string Title { get; private set; }
    public string Process_Kategori { get; private set; }
    public int TimeEstimat { get; private set; }
    public string Kommentar { get; private set; }

    public ICollection<ProjektOpgaveEntity> Projekter { get; set; }

    private readonly IDomainServiceOpgave _domainService;
    public OpgaveEntity(IDomainServiceOpgave domainService, string title, string process_Kategori, int kompetenceId, int timeEstimat, string kommentar)
    {
        _domainService = domainService;

        //if (!CheckIfProcessKategoriIsValid(process_Kategori)) throw new ArgumentException("Process kategori er ikke gyldig");

        Title = title;
        Process_Kategori = process_Kategori;
        KompetenceId = kompetenceId;
        TimeEstimat = timeEstimat;
        Kommentar = kommentar;

    }
    // EF Core only!
    internal OpgaveEntity()
    {
    }

    public void Update(string title, string process_Kategori, int kompetenceId, int timeEstimat, string kommentar)
    {
        Title = title;
        Process_Kategori = process_Kategori;
        KompetenceId = kompetenceId;
        TimeEstimat = timeEstimat;
        Kommentar = kommentar;
    }

    // public bool CheckIfProjektIdIsValid(int projektId)
    // {
    //     if (projektId >= 1) return true;
    //     return false;
    // }

    public bool CheckIfProcessKategoriIsValid(string processKategori)
    {
        switch (processKategori)
        {
            case "Kategori1": return true;
            case "Kategori2": return true;
            case "Kategori3": return true;
            case "Kategori4": return true;
            default: return false;
        }
    }

    public bool CheckIfKompetenceBehovIsValid(string kompetenceBehov)
    {
        switch (kompetenceBehov)
        {
            case "Kompetence1": return true;
            case "Kompetence2": return true;
            case "Kompetence3": return true;
            case "Kompetence4": return true;
            default: return false;
        }
    }
}