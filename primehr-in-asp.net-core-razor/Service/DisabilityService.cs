using HRMSv4.Client.Interface;
using HRMSv4.Client.Pages.Masterdata;
using HRMSv4.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class DisabilityService : IDisability
    {
        private readonly HttpClient _httpClient;

        public DisabilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(HRMSv4.Shared.Masterdata.Disability dis)
        {
            var result = await _httpClient.PostAsJsonAsync("Disability", dis);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Disability/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<HRMSv4.Shared.Masterdata.Disability> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<HRMSv4.Shared.Masterdata.Disability>($"Disability/{id}");
            return result;
        }

        public async Task<IEnumerable<HRMSv4.Shared.Masterdata.Disability>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<HRMSv4.Shared.Masterdata.Disability>>("Disability/All");
            return result;
        }

        public async Task<Response> Update(HRMSv4.Shared.Masterdata.Disability dis)
        {
            var result = await _httpClient.PutAsJsonAsync<HRMSv4.Shared.Masterdata.Disability>($"Disability", dis);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> GetCheckDuplicate(HRMSv4.Shared.Masterdata.Disability dis)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"Disability/CheckDuplicate", dis);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
