using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Kunde.ViewModels;
using Webapp.Infrastructure.Kunde.Contract;
using Webapp.Infrastructure.Kunde.Contract.Dtos;

namespace Webapp.Pages.Kunde;
public class CreateModel : PageModel
{
    private readonly IKundeService _kundeService;
    public CreateModel(IKundeService kundeService)
    {
        _kundeService = kundeService;
    }

    [BindProperty]
    public CreateViewModelKunde CreateViewModel { get; set; } = new();

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var dto = new CreateRequestDtoKunde
        {
            Id = CreateViewModel.Id,
            Name = CreateViewModel.Name,
            Email = CreateViewModel.Email,
            TlfNr = CreateViewModel.TlfNr,
        };

        await _kundeService.Create(dto);

        return RedirectToPage("Index");
    }
}