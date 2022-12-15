using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Opgaver.Contract;
using Webapp.Infrastructure.Opgaver.Contract.Dtos;
using Webapp.Infrastructure.Kompetencer.Contract;
using Webapp.Pages.Opgaver.ViewModels;
using Webapp.Pages.Kompetencer.ViewModels;

namespace Webapp.Pages.Opgaver;

public class UpdateModel : PageModel
{
    private readonly IOpgaverService _opgaverService;
    private readonly IKompetencerService _kompetenceService;
    public UpdateModel(IOpgaverService opgaverService, IKompetencerService kompetenceService)
    {
        _opgaverService = opgaverService;
        _kompetenceService = kompetenceService;
    }

    [BindProperty] public UpdateViewModelOpgaver UpdateViewModel { get; set; } = new();
    public List<IndexViewModelKompetencer> KompetenceIndexViewModels { get; set; } = new();
    public int _opgId { get; set; }
    public async Task OnGet(int id)
    {
        _opgId = id;

        var kompetencer = await _kompetenceService.GetAll();

        kompetencer?.ToList().ForEach(dto => KompetenceIndexViewModels.Add(new IndexViewModelKompetencer
        {
            Id = dto.Id,
            Egenskab = dto.Egenskab
        }));

        var dto = await _opgaverService.Get(id);

        UpdateViewModel.Id = dto.Id;
        UpdateViewModel.KompetenceId = dto.KompetenceId;
        UpdateViewModel.Title = dto.Title;
        UpdateViewModel.Process_Kategori = dto.Process_Kategori;
        UpdateViewModel.TimeEstimat = dto.TimeEstimat;
        UpdateViewModel.Kommentar = dto.Kommentar;
    }
    
    public async Task<IActionResult> OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var dto = new UpdateRequestDtoOpgaver
        {
            Id = UpdateViewModel.Id,
            KompetenceId = UpdateViewModel.KompetenceId,
            Title = UpdateViewModel.Title,
            Process_Kategori = UpdateViewModel.Process_Kategori,
            TimeEstimat = UpdateViewModel.TimeEstimat,
            Kommentar = UpdateViewModel.Kommentar
        };

        await _opgaverService.Update(dto);

        return RedirectToPage("Index");
    }
}
