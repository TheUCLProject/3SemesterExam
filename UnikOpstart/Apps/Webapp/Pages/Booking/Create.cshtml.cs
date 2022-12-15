using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Features.Booking.Contract;
using Webapp.Infrastructure.Features.Booking.Contract.Dtos;
using Webapp.Pages.Booking.ViewModels;

namespace Webapp.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public CreateModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty]
        public CreateViewModelBooking CreateViewModel { get; set; } = new();
        public int _medarbejderId { get; set; }
        public async Task OnGet(int id)
        {
            _medarbejderId = id;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bookingService.Create(new CreateRequestDtoBooking
            {
                MedarbejderId = id,
                Title = CreateViewModel.Title,
                StartDato = CreateViewModel.StartDato,
                SlutDato = CreateViewModel.SlutDato,
                Kommentar = CreateViewModel.Kommentar
            });

            return RedirectToPage("Index", new { id = id });
        }
    }
}
