using Webapp.Infrastructure.Medarbejder.Contract.Dtos;

namespace Webapp.Infrastructure.Medarbejder.Contract.Implementation
{
    public class MedarbejderService : IMedarbejderService
    {
        private readonly HttpClient _httpClient;

        public MedarbejderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(CreateRequestDtoMedarbejder request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Medarbejder/Create", request);
            
            if (response.IsSuccessStatusCode) return;

            var message = response.Content.ReadAsStringAsync().Result;

            throw new Exception(message);
        }
        public async Task Update(UpdateRequestDtoMedarbejder request)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Medarbejder/Update", request);

            if (response.IsSuccessStatusCode) return;

            var message = response.Content.ReadAsStringAsync().Result;

            throw new Exception(message);
        }
        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Medarbejder/Delete/{id}");
        }
        public async Task<QueryResultDtoMedarbejder?> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<QueryResultDtoMedarbejder>($"api/Medarbejder/{id}");
        }
        public async Task<IEnumerable<QueryResultDtoMedarbejder>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoMedarbejder>?>("api/Medarbejder/GetAll");
        }

        public async Task<IEnumerable<QueryResultDtoMedarbejder>?> GetAllMedarbejderByKompetenceId(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoMedarbejder>?>($"api/Medarbejder/GetAllMedarbejderByKompetenceId/{id}");
        }
    }
}