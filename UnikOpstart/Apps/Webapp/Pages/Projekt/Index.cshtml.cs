using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Projekt.ViewModels;
using Webapp.Infrastructure.Projekt.Contract;

namespace Webapp.Pages.Projekt
{
    public class IndexModel : PageModel
    {
        private readonly IProjektService _projektService;
        
        public IndexModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        
        [BindProperty] 
        public List<IndexViewModelProjekt> IndexViewModel { get; set; } = new();
        public int _kundeId;
        public async Task OnGet(int id)
        {
            _kundeId = id;

            var projekts = await _projektService.GetAllByKundeId(_kundeId);
            if (projekts == NotFound() )
            {
                return;
            }

            projekts?.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelProjekt
            {
                Id = dto.Id,
                Name = dto.Name,
                ContactPerson = dto.ContactPerson,
            }));
        }
    }
}
