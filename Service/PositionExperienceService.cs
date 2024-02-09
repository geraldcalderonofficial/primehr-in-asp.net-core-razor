using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class PositionExperienceService : IPositionExperience
    {
        private readonly HttpClient _httpClient;
        public PositionExperienceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Add(PositionExperience pex)
        {
            var result = await _httpClient.PostAsJsonAsync("PositionEducationalBackground", pex);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"PositionExperience/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PositionExperienceViewModel>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionExperienceViewModel>>("PositionExperience/All?id=" + id);
            return result;
        }

        public async Task<HttpResponseMessage> Update(PositionExperience pex)
        {
            var result = await _httpClient.PutAsJsonAsync<PositionExperience>("PositionExperience/", pex);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
    }
}
