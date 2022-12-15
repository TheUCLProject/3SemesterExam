using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Projekt.Contract;
using Webapp.Pages.Projekt.ViewModels;
using Webapp.Infrastructure.Projekt.Contract.Dtos;

namespace Webapp.Pages.Projekt
{
    public class EditModel : PageModel
    {
        private readonly IProjektService _projektService;
        public EditModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        [BindProperty] public UpdateViewModelProjekt EditViewModel { get; set; } = new();
        public async Task OnGet(int id)
        {
            var dto = await _projektService.Get(id);

            EditViewModel.Id = dto.Id;
            EditViewModel.Name = dto.Name;
            EditViewModel.ContactPerson = dto.ContactPerson;
            EditViewModel.ActiveProcess = dto.ActiveProcess;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dto = new UpdateRequestDtoProjekt
            {
                Id = id,
                Name = EditViewModel.Name,
                ContactPerson = EditViewModel.ContactPerson,
                ActiveProcess = EditViewModel.ActiveProcess,
            };

            await _projektService.Edit(dto);

            return RedirectToPage("Index");
        }


    }
}
