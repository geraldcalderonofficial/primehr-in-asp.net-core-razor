using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class TrainingService : ITraining
    {
        private readonly HttpClient _httpClient;

        public TrainingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response> Add(Training training)
        {
            var result = await _httpClient.PostAsJsonAsync("Training", training);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Training/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Training> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Training>($"Training/{id}");
            return result;
        }

        public async Task<IEnumerable<Training>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Training>>("Training/All");
            return result;
        }

        public async Task<IEnumerable<Training>> ListOfTraining()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Training>>("Training/ListOfTraining");
            return result;
        }

        public async Task<Response> Update(Training training)
        {
            var result = await _httpClient.PutAsJsonAsync<Training>($"Training", training);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> GetCheckDuplicate(Training training)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"Training/CheckDuplicate", training);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Training>> GetType(string selected)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Training>>("Training/GetType?selected="+selected);
            return result;
        }

        public async Task<IEnumerable<Training>> GetCategory(string type, string category)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Training>>("Training/GetCategory?type=" + type+ "&category="+category);
            return result;
        }

        public async Task<List<string>> GetTrainingType()
        {
            var result = await _httpClient.GetFromJsonAsync<List<string>>($"Training/GetTrainingType/");
            return result;
        }

        public async Task<List<string>> GetCategories()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<string>>("Training/GetCategories/");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
