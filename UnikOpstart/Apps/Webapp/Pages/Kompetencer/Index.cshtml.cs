using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Kompetencer.Contract;
using Webapp.Pages.Kompetencer.ViewModels;

namespace Webapp.Pages.Kompetencer
{
    public class IndexModel : PageModel
    {

        public IndexModel(IKompetencerService kompetencerService)
        {
            _kompetencerService = kompetencerService;
        }

        [BindProperty] public List<IndexViewModelKompetencer> IndexViewModel { get; set; } = new();
        private readonly IKompetencerService _kompetencerService;
        public int _medarbejderId;

        public async Task OnGet(int id)
        {
            _medarbejderId = id;

            var kompetencer = await _kompetencerService.GetAllByMedarbejderId(id);
            
            if(kompetencer == NotFound()) 
            {
                return;
            }
            
            kompetencer?.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelKompetencer
            {
                Id = dto.Id,
                Egenskab = dto.Egenskab,
            }));
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _kompetencerService.Delete(id);
            return RedirectToPage("Index");
        }

    }
}
