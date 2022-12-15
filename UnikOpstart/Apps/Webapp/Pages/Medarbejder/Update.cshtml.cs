using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Medarbejder.Contract.Dtos;
using Webapp.Pages.Medarbejder.ViewModels;
using Webapp.Infrastructure.Medarbejder.Contract;

namespace Webapp.Pages.Medarbejder
{
    public class EditModel : PageModel
    {
        private readonly IMedarbejderService _medarbejderService;
        public EditModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }

        [BindProperty] public UpdateViewModelMedarbejder UpdateViewModel { get; set; } = new();
        public void OnGet(int id)
        {
            var dto = _medarbejderService.Get(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new UpdateRequestDtoMedarbejder
            {
                Name = UpdateViewModel.Name,
                ProcessRole = UpdateViewModel.ProcessRole,
                Email = UpdateViewModel.Email,
                PhoneNr = UpdateViewModel.PhoneNr
            };


            try
            {
                await _medarbejderService.Update(dto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
