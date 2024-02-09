using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Masterdata;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class EthnicityService : IEthnicity
    {
        private readonly HttpClient _httpClient;

        public EthnicityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(Ethnicity eth)
        {
            var result = await _httpClient.PostAsJsonAsync("Ethnicity", eth);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Ethnicity/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Ethnicity> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<HRMSv4.Shared.Masterdata.Ethnicity>($"Ethnicity/{id}");
            return result;
        }

        public async Task<IEnumerable<Ethnicity>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<HRMSv4.Shared.Masterdata.Ethnicity>>("Ethnicity/All");
            return result;
        }

        public async Task<Response> Update(Ethnicity eth)
        {
            var result = await _httpClient.PutAsJsonAsync<HRMSv4.Shared.Masterdata.Ethnicity>($"Ethnicity", eth);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> GetCheckDuplicate(Ethnicity eth)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"Ethnicity/CheckDuplicate", eth);
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
