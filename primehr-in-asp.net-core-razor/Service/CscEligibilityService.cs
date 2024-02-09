using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CscEligibilityService : ICscEligibility
    {
        private readonly HttpClient _httpClient;

        public CscEligibilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(CscEligibility eligibility)
        {
            var result = await _httpClient.PostAsJsonAsync("CscEligibility", eligibility);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"CscEligibility/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<CscEligibility>> Dropdown()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CscEligibility>>("CscEligibility/Dropdown");
            return result;
        }

        public async Task<CscEligibility> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CscEligibility>($"CscEligibility/{id}");
            return result;
        }



        public async Task<IEnumerable<CscEligibility>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CscEligibility>>("CscEligibility/All");
            return result;
        }

        public async Task<List<SelectListItems>> ListofEligibility()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>("CscEligibility/Dropdown");
            return result;
        }

        public async Task<Response> Update(CscEligibility eligibility)
        {
            var result = await _httpClient.PutAsJsonAsync<CscEligibility>($"CscEligibility", eligibility);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> GetCheckDuplicate(CscEligibility eligibility)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"CscEligibility/CheckDuplicate", eligibility);
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
