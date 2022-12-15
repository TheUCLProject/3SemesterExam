using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Opgaver.ViewModels;
using Webapp.Pages.Kompetencer.ViewModels;
using Webapp.Infrastructure.Opgaver.Contract;
using Webapp.Infrastructure.Kompetencer.Contract;
using Webapp.Infrastructure.Opgaver.Contract.Dtos;

namespace Webapp.Pages.Opgaver;
public class CreateModel : PageModel
{
    private readonly IOpgaverService _opgaverService;
    private readonly IKompetencerService _kompetenceService;
    public CreateModel(IOpgaverService opgaverService, IKompetencerService kompetenceService)
    {
        _opgaverService = opgaverService;
        _kompetenceService = kompetenceService;
    }

    [BindProperty] public CreateViewModelOpgaver CreateViewModel { get; set; } = new();
    public List<IndexViewModelKompetencer> KompetenceIndexViewModels { get; set; } = new();
    public int _projektId;
    
    public async Task<IActionResult> OnGet(int id)
    {
        _projektId = id;

        var kompetencer = await _kompetenceService.GetAll();

        kompetencer?.ToList().ForEach(dto => KompetenceIndexViewModels.Add(new IndexViewModelKompetencer
        {
            Id = dto.Id,
            Egenskab = dto.Egenskab
        }));

        return Page();
    }

    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var dto = new CreateRequestDtoOpgaver
        {
            ProjektId = id,
            KompetenceId = CreateViewModel.KompetenceId,
            Title = CreateViewModel.Title,
            Process_Kategori = CreateViewModel.Process_Kategori,
            TimeEstimat = CreateViewModel.TimeEstimat,
            //Kommentar = CreateViewModel.Kommentar //for some reason this doesnt work.
        };

        await _opgaverService.Create(dto);

        return RedirectToPage("Index", new { id = id });
    }
}