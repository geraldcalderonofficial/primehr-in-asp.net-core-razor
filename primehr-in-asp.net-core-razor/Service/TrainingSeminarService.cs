using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class TrainingSeminarService : ITrainingSeminar
    {
        private readonly HttpClient _httpClient;
        public TrainingSeminarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Add(TrainingSeminar ts)
        {
            var result = await _httpClient.PostAsJsonAsync("TrainingSeminar/Arvin", ts);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"TrainingSeminar/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<TrainingSeminar> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<TrainingSeminar>($"TrainingSeminar/{id}");
            return result;
        }

        public async Task<IEnumerable<TrainingSeminarListview>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<TrainingSeminarListview>>("TrainingSeminar/All?id=" + id);
            return result;
        }

        public async Task<HttpResponseMessage> Update(TrainingSeminar ts)
        {
            var result = await _httpClient.PutAsJsonAsync<TrainingSeminar>("TrainingSeminar/", ts);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
    }
}
