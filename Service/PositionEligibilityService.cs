using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class PositionEligibilityService : IPositionEligibility
    {
        private readonly HttpClient _httpClient;

        public PositionEligibilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PositionEligibilityViewModel>> Add(PositionEligibilityViewModel positionEligibility)
        {
            var result = await _httpClient.PostAsJsonAsync("PositionEligibility", positionEligibility);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PositionEligibilityViewModel>>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"PositionEligibility/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<PositionEligibilityViewModel> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionEligibilityViewModel>($"PositionEligibility/{id}");
            return result;
        }

        public async Task<IEnumerable<PositionEligibilityViewModel>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionEligibilityViewModel>>("PositionEligibility");
            return result;
        }

        public async Task<IEnumerable<PositionEligibilityViewModel>> GetGet(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionEligibilityViewModel>>($"PositionEligibility/{id}");
                return result;
        }

        public async Task<Response> Update(PositionEligibilityViewModel positionEligibility)
        {

                var result = await _httpClient.PutAsJsonAsync<PositionEligibilityViewModel>($"PositionEligibility", positionEligibility);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
        
        }

    }
}
