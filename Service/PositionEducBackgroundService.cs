using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class PositionEducBackgroundService : IPositionEducBackground
    {
        private readonly HttpClient _httpClient;
        public PositionEducBackgroundService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PositionEducationalBackground> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionEducationalBackground>($"PositionEducationalBackground/{id}");
            return result;
        }

        public async Task<HttpResponseMessage> Add(PositionEducationalBackground peb)
        {
            var result = await _httpClient.PostAsJsonAsync("PositionEducationalBackground", peb);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Update(PositionEducationalBackground peb)
        {
            var result = await _httpClient.PutAsJsonAsync<PositionEducationalBackground>("PositionEducationalBackground/", peb);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"PositionEducationalBackground/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PositionEducationalBackgroundViewModel>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionEducationalBackgroundViewModel>>("PositionEducationalBackground/All?id=" + id);
            return result;
        }

    }
}
