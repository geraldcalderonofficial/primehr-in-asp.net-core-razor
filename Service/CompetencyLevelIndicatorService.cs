using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CompetencyLevelIndicatorService : ICompetencyLevelIndicator
    {
        private readonly HttpClient _httpClient;

        public CompetencyLevelIndicatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CompetencyLevelIndicator>> Add(CompetencyLevelIndicator comp)
        {
            var result = await _httpClient.PostAsJsonAsync("CompetencyLevelIndicator", comp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CompetencyLevelIndicator>>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"CompetencyLevelIndicator/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        //public async Task<CompetencyLevelIndicatorView> Get(long id)
        //{
        //    var result = await _httpClient.GetFromJsonAsync<CompetencyLevelIndicatorView>($"/api/CompetencyLevelIndicator/{id}");
        //    return result;
        //}

        //public async Task<IEnumerable<CompetencyLevelIndicatorView>> GetAll()
        //{
        //    var result = await _httpClient.GetFromJsonAsync<IEnumerable<CompetencyLevelIndicatorView>>("/api/CompetencyLevelIndicator");
        //    return result;
        //}

        public async  Task<IEnumerable<CompetencyLevelIndicatorView>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CompetencyLevelIndicatorView>>($"CompetencyLevelIndicator/{id}");
            return result;
        }

        public async Task<IEnumerable<CompetencyLevelIndicatorView>> GetLevel(int id, string lvl)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CompetencyLevelIndicatorView>>($"CompetencyLevelIndicator/GetLevel/{id}/{lvl}");
            return result;
        }

        public async Task<Response> Update(CompetencyLevelIndicator comp)
        {
            var result = await _httpClient.PutAsJsonAsync<CompetencyLevelIndicator>($"CompetencyLevelIndicator", comp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
