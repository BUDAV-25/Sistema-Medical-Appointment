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
        public virtual async Task<T> GetAllConsumption<T>(string urlTask)
        {
            var response = await _httpClient.GetAsync(urlTask);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public virtual async Task<T> GetByIdConsumption<T>(string urlTask)
        {
            var response = await _httpClient.GetAsync(urlTask);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public virtual async Task<T> SaveConsumption<T>(string urlTask, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(urlTask, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public virtual async Task<T> UpdateConsumption<T>(string urlTask, T data)
        {
            var response = await _httpClient.PutAsJsonAsync(urlTask, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
