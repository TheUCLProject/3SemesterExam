using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Projekt.Contract;
using Webapp.Infrastructure.Medarbejder.Contract;
using Webapp.Infrastructure.Kunde.Contract;
using Webapp.Infrastructure.Opgaver.Contract;
using Webapp.Infrastructure.Features.Booking.Contract;
using Webapp.Infrastructure.Features.Booking.Contract.Dtos;
using Webapp.Pages.Projekt.ViewModels;
using Webapp.Pages.Kunde.ViewModels;
using Webapp.Pages.Medarbejder.ViewModels;
using Webapp.Pages.Opgaver.ViewModels;
using UnikOpstart.Webapp.Infrastructure.Booking.Features.Booking.Contract.Dtos;
using UnikOpstart.Webapp.Pages.Medarbejder.Sælger.ViewModels;


namespace Webapp.Pages.Medarbejder.Sælger
{
    public class IndexModel : PageModel
    {
        private readonly IProjektService _projektService;
        private readonly IMedarbejderService _medarbejderService;
        private readonly IKundeService _kundeService;
        private readonly IOpgaverService _opgaverService;
        private readonly IBookingService _bookingService;

        
        public IndexModel(IProjektService projektService, 
                          IMedarbejderService medarbejderService, 
                          IKundeService kundeService, 
                          IOpgaverService opgaverService, 
                          IBookingService bookingService)
        {
            _projektService = projektService;
            _medarbejderService = medarbejderService;
            _kundeService = kundeService;
            _opgaverService = opgaverService;
            _bookingService = bookingService;
        }

        [BindProperty] public IndexViewModelProjekt ProjektViewModel { get; set; } = new();
        [BindProperty] public IndexViewModelKunde KundeViewModel { get; set; } = new();
        [BindProperty] public List<IndexViewModelOpgaver> OpgaveViewModel { get; set; } = new();
        [BindProperty] public List<MedarbejderForProjektView> TeknikerForProjektViewModel { get; set; } = new();
        [BindProperty] public List<MedarbejderForProjektView> KonverterForProjektViewModel { get; set; } = new();
        [BindProperty] public List<MedarbejderForProjektView> KonsulentForProjektViewModel { get; set; } = new();
        public List<MedarbejderForProjektView> MedarbejderTilknyttetProjektViewModel { get; set; } = new();
        public int _projektId;
        public string _startDato;
        public int i = 0;
        [BindProperty] public List<CreateBookingView> CreateBookings { get; set; } = new();
        
        public async Task OnGet(int projektId, int kundeId)
        {
            _projektId = projektId;
            var projekt = await _projektService.Get(projektId);
            
            ProjektViewModel.Id = projekt.Id;
            ProjektViewModel.KundeId = projekt.KundeId;
            ProjektViewModel.Name = projekt.Name;
            ProjektViewModel.ContactPerson = projekt.ContactPerson;
            ProjektViewModel.ActiveProcess = projekt.ActiveProcess;

            var kunde = await _kundeService.Get(kundeId);

            KundeViewModel.Id = kunde.Id;
            KundeViewModel.Name = kunde.Name;
            KundeViewModel.Email = kunde.Email;
            KundeViewModel.TlfNr = kunde.TlfNr;

          //  var var medarbejdereTilknyttetProjekt = await 

            if(_startDato == null)
            {
                _startDato = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }

            var opgaver = await _opgaverService.GetAllByProjektId(_projektId);

            opgaver?.ToList().ForEach(dto => OpgaveViewModel.Add(new IndexViewModelOpgaver
            {
                Id = dto.Id,
                KompetenceId = dto.KompetenceId,
                Title = dto.Title,
                Process_Kategori = dto.Process_Kategori,
                TimeEstimat = dto.TimeEstimat,
                Kommentar = dto.Kommentar
            }));

            // For each opgave, find medarbejder med kompetence indenfor process kategori til opgaven
            foreach (var opg in OpgaveViewModel)
            {
                CreateBookings.Add(new CreateBookingView
                {
                    OpgaveId = opg.Id
                });

                if(ProjektViewModel.ActiveProcess=="Opstart" && opg.Process_Kategori == "Teknik")
                {
                    var kompententeMedarbejdere = await _medarbejderService.GetAllMedarbejderByKompetenceId(opg.KompetenceId);

                    foreach (var m in kompententeMedarbejdere)
                    {
                        if(opg.Process_Kategori == "Teknik" && m.ProcessRole == "Tekniker")
                        {
                            TeknikerForProjektViewModel.Add (new MedarbejderForProjektView
                            {
                                OpgaveId = opg.Id,
                                MedarbejderId = m.Id,
                                Navn = m.Name,
                                Process_Kategori = opg.Process_Kategori,
                            });
                        }
                    }
                }
                else if(ProjektViewModel.ActiveProcess=="Teknik" && opg.Process_Kategori == "Konvertering")
                {

                    var kompententeMedarbejdere = await _medarbejderService.GetAllMedarbejderByKompetenceId(opg.KompetenceId);
                    
                    foreach(var m in kompententeMedarbejdere)
                    {
                        if(opg.Process_Kategori == "Konvertering" && m.ProcessRole == "Konverter")
                        {
                            KonverterForProjektViewModel.Add (new MedarbejderForProjektView
                            {
                                OpgaveId = opg.Id,
                                MedarbejderId = m.Id,
                                Navn = m.Name,
                                Process_Kategori = opg.Process_Kategori,
                            });
                        }
                    }
                }
                else if(ProjektViewModel.ActiveProcess=="Konvertering" && opg.Process_Kategori == "Konsultation")
                {
                    var kompententeMedarbejdere = await _medarbejderService.GetAllMedarbejderByKompetenceId(opg.KompetenceId);
                    
                    foreach (var m in kompententeMedarbejdere)
                    {
                        if(opg.Process_Kategori == "Konsultation" && m.ProcessRole == "Konsulent")
                        {
                            KonsulentForProjektViewModel.Add (new MedarbejderForProjektView
                            {
                                OpgaveId = opg.Id,
                                MedarbejderId = m.Id,
                                Navn = m.Name,
                                Process_Kategori = opg.Process_Kategori,
                            });
                        }
                    }
                }
            }
            
        }
        

        public async Task<IActionResult> OnPost()
        {
            int timeEstimat = 0;
            int daysIn = 0;
            foreach (var booking in CreateBookings)
            {
                if(booking.MedarbejderId != 0)
                {
                    timeEstimat = booking.TimeEstimat;

                    var createRequest = new CreateRequestDtoBooking
                    {
                        Title = "Unik Opgave",
                        OpgaveId = booking.OpgaveId,
                        MedarbejderId = booking.MedarbejderId,
                        StartDato = DateTime.Parse(_startDato).AddDays(daysIn).ToString(),
                        SlutDato = DateTime.Parse(_startDato).AddDays(timeEstimat).ToString()
                    };

                    await _bookingService.Create(createRequest);

                    daysIn += timeEstimat+1;
                }
            }
            return Page();
        }
    }
}