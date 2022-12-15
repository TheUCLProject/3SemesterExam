using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Projekt.Contract;
using Webapp.Infrastructure.Projekt.Contract.Dtos;
using Webapp.Pages.Projekt.ViewModels;

namespace Webapp.Pages.Projekt
{
    public class CreateModel : PageModel
    {
        private readonly IProjektService _projektService;
        public CreateModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        [BindProperty] 
        public CreateViewModelProjekt CreateViewModel { get; set; } = new();
        public int _kundeId;
        public void OnGet(int id)
        {
            _kundeId = id;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dto = new CreateRequestDtoProjekt()
            {
                KundeId = id,
                Name = CreateViewModel.Name,
                ContactPerson = CreateViewModel.ContactPerson,
                ActiveProcess = "Oprettet"
            };
            _kundeId = id;
            await _projektService.Create(dto);

            return RedirectToPage("Index", new { id = id });
        }
    }
}
