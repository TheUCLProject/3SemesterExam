using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Medarbejder.ViewModels;
using Webapp.Infrastructure.Medarbejder.Contract;

namespace Webapp.Pages.Medarbejder
{
    public class IndexModel : PageModel
    {
        [BindProperty] 
        public List<IndexViewModelMedarbejder> IndexViewModel { get; set; } = new();
        private readonly IMedarbejderService _medarbejderService;
        
        public IndexModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }
        public async Task OnGet()
        {
            var medarbejder = await _medarbejderService.GetAll();
            
            medarbejder?.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelMedarbejder
            {
                Id = dto.Id,
                Name = dto.Name,
                ProcessRole = dto.ProcessRole,
                Email = dto.Email,
                PhoneNr = dto.PhoneNr
            }));
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _medarbejderService.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
