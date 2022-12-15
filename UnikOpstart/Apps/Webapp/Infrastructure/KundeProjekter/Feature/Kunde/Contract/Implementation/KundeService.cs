using Webapp.Infrastructure.Kunde.Contract.Dtos;

namespace Webapp.Infrastructure.Kunde.Contract.Implementation;
public class KundeService : IKundeService
{
    private readonly HttpClient _httpClient;

    public KundeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    async Task IKundeService.Create(CreateRequestDtoKunde request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Kunde/Create", request);

        if (response.IsSuccessStatusCode) return;

        var message = response.Content.ReadAsStringAsync().Result;

        throw new Exception(message);
    }

    async Task<QueryResultDtoKunde?> IKundeService.Get(int id)
    {
        return await _httpClient.GetFromJsonAsync<QueryResultDtoKunde>($"api/Kunde/{id}");
    }

    async Task<IEnumerable<QueryResultDtoKunde>?> IKundeService.GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoKunde>?>("api/Kunde/GetAll");
    }

    async Task IKundeService.Update(UpdateRequestDtoKunde request)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Kunde/Update", request);

        if (response.IsSuccessStatusCode) return;

        var message = response.Content.ReadAsStringAsync().Result;

        throw new Exception(message);
    }

    async Task IKundeService.Delete(int id)
    {
        await _httpClient.DeleteAsync($"api/Kunde/{id}");
    }
}