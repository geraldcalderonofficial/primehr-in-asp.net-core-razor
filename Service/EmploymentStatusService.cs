using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class EmploymentStatusService : IEmploymentStatus
    {
        private readonly HttpClient _httpClient;
        public EmploymentStatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(EmploymentStatus status)
        {
            var result = await _httpClient.PostAsJsonAsync("EmploymentStatus", status);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"EmploymentStatus/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<EmploymentStatus> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmploymentStatus>($"EmploymentStatus/{id}");
            return result;
        }

        public async Task<IEnumerable<EmploymentStatus>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmploymentStatus>>("EmploymentStatus");
            return result;
        }

        public async Task<Response> Update(EmploymentStatus status)
        {
            var result = await _httpClient.PutAsJsonAsync<EmploymentStatus>($"EmploymentStatus", status);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<IEnumerable<EmploymentStatus>> Get(bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmploymentStatus>>($"EmploymentStatus/List/{isPlantilla}");
            return result;
        }

        public async Task<IEnumerable<EmploymentStatusListview>> GetFilter()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmploymentStatusListview>>("EmploymentStatus/GetFilter");
            return result;
        }

        public async Task<Response> GetCheckDuplicate(EmploymentStatus status)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"EmploymentStatus/CheckDuplicate", status);
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
