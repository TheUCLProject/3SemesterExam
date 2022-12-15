using UnikOpstart.Webapp.Infrastructure.Booking.Features.Booking.Contract.Dtos;
using Webapp.Infrastructure.Features.Booking.Contract;
using Webapp.Infrastructure.Features.Booking.Contract.Dtos;

namespace Webapp.Infrastructure.Features.Booking.Contract.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        async Task IBookingService.Create(CreateRequestDtoBooking requestDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Booking/Create", requestDto);
            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        async Task IBookingService.Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Booking/Delete/{id}");
            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }


        async Task<IEnumerable<QueryResultDtoBooking>?> IBookingService.GetAllByMedarbejderId(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoBooking>>($"api/Booking/GetAllByMedarbejderId/{id}");
        }

        async Task IBookingService.Update(UpdateRequestDtoBooking requestDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Booking/Update", requestDto);
            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        public async Task<QueryResultDtoBooking> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<QueryResultDtoBooking>($"api/Booking/Get/{id}");
        }

        public async Task<QueryResultDtoBooking> GetAvailable(GetRequestDtoBooking request)
        {
            return await _httpClient.GetFromJsonAsync<QueryResultDtoBooking>($"api/Booking/GetAvailable/{request}");
        }
    }
}