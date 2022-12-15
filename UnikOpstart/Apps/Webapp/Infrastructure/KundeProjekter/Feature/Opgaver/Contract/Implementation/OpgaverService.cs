using Webapp.Infrastructure.Opgaver.Contract.Dtos;

namespace Webapp.Infrastructure.Opgaver.Contract.Implementation;
public class OpgaverService : IOpgaverService
{
    private readonly HttpClient _httpClient;

    public OpgaverService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    async Task IOpgaverService.Create(CreateRequestDtoOpgaver request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Opgave/Create", request);

        if (response.IsSuccessStatusCode) return;

        var message = response.Content.ReadAsStringAsync().Result;

        throw new Exception(message);
    }

    async Task<QueryResultDtoOpgaver?> IOpgaverService.Get(int id)
    {
        return await _httpClient.GetFromJsonAsync<QueryResultDtoOpgaver>($"api/Opgave/{id}");
    }

    async Task<IEnumerable<QueryResultDtoOpgaver>?> IOpgaverService.GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoOpgaver>?>("api/Opgave/GetAll");
    }

    async Task IOpgaverService.Update(UpdateRequestDtoOpgaver request)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Opgave/Update", request);

        if (response.IsSuccessStatusCode) return;

        var message = response.Content.ReadAsStringAsync().Result;

        throw new Exception(message);
    }

    async Task IOpgaverService.Delete(int id)
    {
        await _httpClient.DeleteAsync($"api/Opgave/{id}");
    }

    public async Task<IEnumerable<QueryResultDtoOpgaver>?> GetAllByProjektId(int projektId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoOpgaver>?>($"api/Opgave/GetAllOpgaverForProjekt/{projektId}");
    }
}