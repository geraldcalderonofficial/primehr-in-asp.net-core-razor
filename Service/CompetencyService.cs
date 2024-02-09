using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CompetencyService : ICompetency
    {
        private readonly HttpClient _httpClient;
        public CompetencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Competency>> Add(Competency comp)
        {
            var result = await _httpClient.PostAsJsonAsync("Competency", comp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject <List<Competency>> (res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Competency/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Competency> Get(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<Competency>($"Competency/{id}");
            return result;
        }

        public async Task<IEnumerable<Competency>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Competency>>("Competency");
            return result;
        }

        public async Task<Response> LevelList(CompetencyLevelViewList lvl)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Competency/LevelList", lvl);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Update(Competency comp)
        {
            var result = await _httpClient.PutAsJsonAsync<Competency>($"Competency", comp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
