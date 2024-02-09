using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class PositionCompetencyService : IPositionCompetency
    {
        private readonly HttpClient _httpClient;
        public PositionCompetencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Add(PositionCompetency pc)
        {
            var result = await _httpClient.PostAsJsonAsync("PositionCompetency", pc);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"PositionCompetency/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PositionCompetencyViewModel>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionCompetencyViewModel>>("PositionCompetency/All?id=" + id);
            return result;
        }

        public async Task<HttpResponseMessage> Update(PositionCompetency pc)
        {
            var result = await _httpClient.PutAsJsonAsync<PositionCompetency>("PositionCompetency/", pc);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
    }
}
