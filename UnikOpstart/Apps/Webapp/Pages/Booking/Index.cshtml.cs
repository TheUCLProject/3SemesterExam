using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webapp.Pages.Booking.ViewModels;
using Webapp.Infrastructure.Features.Booking.Contract;

namespace Webapp.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public List<IndexViewModelBooking> IndexViewModel { get; set; } = new();
        public int _medarbejderId { get; set; }
        
        public async Task OnGet(int id)
        {
            _medarbejderId = id;
            var bookings = await _bookingService.GetAllByMedarbejderId(id);

            if (bookings == NotFound())
            {
                return;
            }

            bookings?.ToList().ForEach(dto => IndexViewModel.Add(new IndexViewModelBooking
            {
                Id = dto.Id,
                Title = dto.Title,
                StartDato = dto.StartDato,
                SlutDato = dto.SlutDato,
                Kommentar = dto.Kommentar 
            }));
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _bookingService.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
