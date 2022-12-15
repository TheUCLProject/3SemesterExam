using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Medarbejder.ViewModels;
using Webapp.Infrastructure.Medarbejder.Contract;
using Webapp.Infrastructure.Medarbejder.Contract.Dtos;

namespace Webapp.Pages.Medarbejder
{
    public class CreateModel : PageModel
    {
        private readonly IMedarbejderService _medarbejderService;
        public CreateModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }

        [BindProperty] 
        public CreateViewModelMedarbejder CreateViewModel { get; set; } = new();
        
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var dto = new CreateRequestDtoMedarbejder
            {
                Name = CreateViewModel.Name,
                ProcessRole = CreateViewModel.ProcessRole
            };
            
            await _medarbejderService.Create(dto);
            
            return RedirectToPage("Index");
        }
    }
}
