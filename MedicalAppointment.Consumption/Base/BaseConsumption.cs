

using System.Net.Http.Json;

namespace MedicalAppointment.Consumption.Base
{
    public class BaseConsumption : IBaseConsumption
    {
        private readonly HttpClient _httpClient;
        public BaseConsumption(HttpClient httpClient)
        {
            _httpClient = httpClient;  
        }

        public virtual async Task<T> GetAllConsumption<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public async Task<T> GetByIdConsumption<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public virtual async Task<T> SaveConsumption<T>(string url, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public virtual async Task<T> UpdateConsumption<T>(string url, T data)
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
