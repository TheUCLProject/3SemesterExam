namespace UnikOpstart.Services.Booking.Api.Infrastructure.MedarbejderKompetencer.Features.Medarbejder.Implementations;
public class MedarbejderService : IMedarbejderService
{
    private readonly HttpClient _httpClient;
    public MedarbejderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> MedarbejderExistsInDb(int id)
    {
        return await _httpClient.GetFromJsonAsync<bool>($"api/Medarbejder/MedarbejderExistsInDb/{id}");
    }
}