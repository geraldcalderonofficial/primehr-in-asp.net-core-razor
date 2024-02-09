using System.Net.Http.Json;
using System.Text.Json;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;

namespace HRMSv4.Client.Service
{
    public class LevelService : ILevel
    {
        private readonly HttpClient _httpClient;

        public LevelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Level>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Level>>("Level");
            return result;
        }

        public async Task<List<Level>> Add(Level lvl)
        {
            var result = await _httpClient.PostAsJsonAsync("Level", lvl);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Level>>(res);
        }

        public async Task<Response> Update(Level lvl)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<Level>($"Level", lvl);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Level/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Level> Get(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<Level>($"Level/{id}");
            return result;
        }

        public async Task<string> GetLabel()
        {
            var result = await _httpClient.GetFromJsonAsync<JsonElement>("Level/Label");
            string label = result.GetProperty("label").GetString();
            return label;
        }

        public async Task<List<SelectListItems>> ListofChildLevels(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Level/ChildLevels/{id}");
            return result;
        }

        public async Task<SetLevels> GetLevels(int levelId)
        {
            var result = await _httpClient.GetFromJsonAsync<SetLevels>("Level/SelectedLevels?levelId=" + levelId);
            return result;
        }

        public async Task<int> GetChildLevelsCount(int levelId)
        {
            var result = await _httpClient.GetFromJsonAsync<int>("Level/CheckChildLevelsCount?levelId=" + levelId);
            return result;
        }

        public async Task<List<ParentChildLevel>> ParentToChildLevels()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ParentChildLevel>>($"Level/ParentToChildLevels");
            return result;
        }
    }
}
