using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Joins;

namespace HRMSv4.Client.Service
{
    public class OverallResultService : IOverallResult
    {
        private readonly HttpClient _httpClient;
        public OverallResultService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ScreeningCriteriaItem>> GetCriteriaItems()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ScreeningCriteriaItem>>($"OverallResult/GetCriteriaItems");
            return result;
        }

        public async Task<List<OverallResult>> GetOverallResult(int positionId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<OverallResult>>($"OverallResult/GetOverallResult?positionid=" + positionId);
            return result;
        }

        public async Task<Response> PostCriteriaItem(ScreeningCriteriaItem sci)
        {
            var result = await _httpClient.PostAsJsonAsync<ScreeningCriteriaItem>($"OverallResult/PostCriteriaItem", sci);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> PutCriteriaItem(ScreeningCriteriaItem sci)
        {
            var result = await _httpClient.PutAsJsonAsync<ScreeningCriteriaItem>("OverallResult/PutCriteriaItem", sci);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
