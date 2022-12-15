using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Kompetencer.ViewModels;
using Webapp.Infrastructure.Kompetencer.Contract;
using Webapp.Infrastructure.Kompetencer.Contract.Dtos;
using UnikOpstart.Webapp.Infrastructure.MedarbejderKompetencer.Feature.Kompetencer.Contract.Dtos;

namespace Webapp.Pages.Kompetencer
{
    public class CreateModel : PageModel
    {

        private readonly IKompetencerService _kompetencerService;
        public CreateModel(IKompetencerService kompetencerService)
        {
            _kompetencerService = kompetencerService;
        }

        public List<IndexViewModelKompetencer> IndexViewModel { get; set; } = new();
        [BindProperty]
        public CreateViewModelKompetencer CreateViewModel { get; set; } = new();
        public int _medarbejderId;

        public async Task OnGet(int id)
        {
            _medarbejderId = id;

            var kompetencer = await _kompetencerService.GetAll();

            kompetencer.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelKompetencer
            {
                Id = dto.Id,
                Egenskab = dto.Egenskab,
            }));
        }
        public async Task<IActionResult> OnPost(int kompetenceFromListId, int medarbejderId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(kompetenceFromListId == 0)
            {
                var dto = new CreateRequestDtoKompetencer
                {
                    Egenskab = CreateViewModel.Egenskab,
                    MedarbejderId = medarbejderId,
                };

                await _kompetencerService.Create(dto);
            }
            else
            {
                var dto = new CreateRequestDtoMedarbejderKompetence
                {
                    KompetenceId = kompetenceFromListId,
                    MedarbejderId = medarbejderId
                };

                await _kompetencerService.Add(dto);
            }
                return RedirectToPage("/Kompetencer/Index");
        }
    }
}
