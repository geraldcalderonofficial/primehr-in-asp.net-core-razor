using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class PositionTrainingService : IPositionTraining
    {
        private readonly HttpClient _httpClient;

        public PositionTrainingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PositionTrainingViewModel>> Add(PositionTrainingViewModel positionTraining)
        {
            var result = await _httpClient.PostAsJsonAsync("PositionTraining", positionTraining);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PositionTrainingViewModel>>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"PositionTraining/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<IEnumerable<PositionTrainingViewModel>> Get(int id)
        {
              var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionTrainingViewModel>>($"PositionTraining/{id}");
              return result;
        }

        public async Task<IEnumerable<PositionTrainingViewModel>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionTrainingViewModel>>("PositionTraining");
            return result;
        }

        public async Task<Response> Update(PositionTrainingViewModel positionTraining)
        {
            var result = await _httpClient.PutAsJsonAsync<PositionTrainingViewModel>($"PositionTraining", positionTraining);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

  
    }
}
