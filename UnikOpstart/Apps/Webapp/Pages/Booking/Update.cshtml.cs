using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Infrastructure.Features.Booking.Contract;
using Webapp.Infrastructure.Features.Booking.Contract.Dtos;
using Webapp.Pages.Booking.ViewModels;

namespace Webapp.Pages.Booking
{
    public class UpdateModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public UpdateModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public UpdateViewModelBooking UpdateViewModel { get; set; } = new();

        public async Task OnGet(int id)
        {
            var booking = await _bookingService.GetById(id);

            UpdateViewModel.Id = booking.Id;
            UpdateViewModel.Title = booking.Title;
            UpdateViewModel.StartDato = booking.StartDato;
            UpdateViewModel.SlutDato = booking.SlutDato;
            UpdateViewModel.Kommentar = booking.Kommentar;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bookingService.Update(new UpdateRequestDtoBooking
            {
                Id = UpdateViewModel.Id,
                Title = UpdateViewModel.Title,
                StartDato = UpdateViewModel.StartDato,
                SlutDato = UpdateViewModel.SlutDato,
                Kommentar = UpdateViewModel.Kommentar
            });

            return RedirectToPage("Index");
        }
    }
}
