using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Opgaver.Contract;
using Webapp.Pages.Opgaver.ViewModels;

namespace Webapp.Pages.Opgaver;

public class IndexModel : PageModel
{
    private readonly IOpgaverService _opgaverService;

    public IndexModel(IOpgaverService opgaverService)
    {
        _opgaverService = opgaverService;
    }

    [BindProperty] public List<IndexViewModelOpgaver> IndexViewModel { get; set; } = new();
    public int _projektId;

    public async Task OnGet(int id)
    {
        _projektId = id;
        
        var opgaver = await _opgaverService.GetAllByProjektId(id);

        if(opgaver != NotFound()) 
        {
            opgaver?.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelOpgaver
            {
                Id = dto.Id,
                KompetenceId = dto.KompetenceId,
                Title = dto.Title,
                Process_Kategori = dto.Process_Kategori,
                TimeEstimat = dto.TimeEstimat,
                Kommentar = dto.Kommentar
            }));
        }   

        
    }
    public async Task<IActionResult> OnPostDelete(int id, int projektId)
    {
        await _opgaverService.Delete(id);
        return RedirectToPage("Index", new { id = projektId });
    }
}
