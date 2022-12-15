using UnikOpstart.Webapp.Infrastructure.MedarbejderKompetencer.Feature.Kompetencer.Contract.Dtos;
using Webapp.Infrastructure.Kompetencer.Contract;
using Webapp.Infrastructure.Kompetencer.Contract.Dtos;

namespace Webapp.Infrastructure.Kompetencer.Contract.Implemenation
{
    public class KompetencerService : IKompetencerService
    {
        private readonly HttpClient _httpClient;
        public KompetencerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(CreateRequestDtoKompetencer request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Kompetencer/CreateAndAdd", request);

            if (response.IsSuccessStatusCode) return;

            var message = response.Content.ReadAsStringAsync().Result;
            throw new Exception(message);
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Kompetencer/Delete/{id}");
        }

        public async Task Update(UpdateRequestDtoKompetencer request)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Kompetencer/Update", request);

            if (response.IsSuccessStatusCode) return;

            var message = response.Content.ReadAsStringAsync().Result;
            throw new Exception(message);
        }

        public async Task<QueryResultDtoKompetencer?> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<QueryResultDtoKompetencer>($"api/Kompetencer/{id}");
        }

        public async Task<IEnumerable<QueryResultDtoKompetencer>?> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoKompetencer>?>("api/Kompetencer/GetAll");
        }

        public async Task<IEnumerable<QueryResultDtoKompetencer>?> GetAllByMedarbejderId(int medarbejderId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<QueryResultDtoKompetencer>?>($"api/Kompetencer/GetAllByMedarbejderId/{medarbejderId}");
        }

        public async Task Add(CreateRequestDtoMedarbejderKompetence requestDtoMedarbejderKompetence)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Kompetencer/Add", requestDtoMedarbejderKompetence);
        }
    }
}