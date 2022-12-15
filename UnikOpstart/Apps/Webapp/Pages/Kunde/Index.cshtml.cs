using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Kunde.Contract;
using Webapp.Pages.Kunde.ViewModels;

namespace Webapp.Pages.Kunde;

public class IndexModel : PageModel
{
    [BindProperty]
    public List<IndexViewModelKunde> IndexViewModel { get; set; } = new();
    private readonly IKundeService _kundeService;

    public IndexModel(IKundeService kundeService)
    {
        _kundeService = kundeService;
    }
    public async Task OnGet()
    {
        var kunde = await _kundeService.GetAll();

        kunde?.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelKunde
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            TlfNr = dto.TlfNr,
        }));
    }
    public async Task<IActionResult> OnPostDelete(int id)
    {
        await _kundeService.Delete(id);
        return RedirectToPage();
    }
}