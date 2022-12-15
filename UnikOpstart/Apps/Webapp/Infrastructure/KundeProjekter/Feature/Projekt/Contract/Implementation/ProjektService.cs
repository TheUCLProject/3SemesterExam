using Webapp.Infrastructure.Projekt.Contract.Dtos;

namespace Webapp.Infrastructure.Projekt.Contract.Implementation
{
    public class ProjektService : IProjektService
    {
        private readonly HttpClient _httpClient;

        public ProjektService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(CreateRequestDtoProjekt request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projekt/create", request);
            
            if (response.IsSuccessStatusCode) return;

            var message = response.Content.ReadAsStringAsync().Result;

            throw new Exception(message);
        }
        public async Task Edit (UpdateRequestDtoProjekt request)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Projekt/Update", request);

            if (response.IsSuccessStatusCode) return;

            var message = response.Content.ReadAsStringAsync().Result;

            throw new Exception(message);
        }
        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Projekt/delete/{id}");
        }
        public async Task<QueryResultDtoProjekt?> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<QueryResultDtoProjekt>($"api/Projekt/{id}");
        }
        public async Task<IEnumerable<QueryResultDtoProjekt>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoProjekt>?>("api/Projekt/getall");
        }

        public async Task<IEnumerable<QueryResultDtoProjekt>?> GetAllByKundeId(int kundeId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoProjekt>?>($"api/Projekt/GetAllProjekterByKundeId/{kundeId}");
        }
    }
    
}