using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Kunde.Contract;
using Webapp.Infrastructure.Kunde.Contract.Dtos;
using Webapp.Pages.Kunde.ViewModels;

namespace Webapp.Pages.Kunde;

public class UpdateModel : PageModel
{
    private readonly IKundeService _KundeService;
    public UpdateModel(IKundeService KundeService)
    {
        _KundeService = KundeService;
    }

    [BindProperty]
    public UpdateViewModelKunde UpdateViewModel { get; set; } = new();

    public async Task OnGet(int id)
    {
        var dto = await _KundeService.Get(id);

        UpdateViewModel.Id = dto.Id;
        UpdateViewModel.Name = dto.Name;
        UpdateViewModel.Email = dto.Email;
        UpdateViewModel.TlfNr = dto.TlfNr;
    }

    public async Task<IActionResult> OnPost(int id)
   {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var dto = new UpdateRequestDtoKunde
        {
            Id = id,
            Name = UpdateViewModel.Name,
            Email = UpdateViewModel.Email,
            TlfNr = UpdateViewModel.TlfNr,
        };

        await _KundeService.Update(dto);

        return RedirectToPage("Index");
    }
}
