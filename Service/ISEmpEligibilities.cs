using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpEligibilities : IEmpEligibilities
    {
        private readonly HttpClient _httpClient;
        public ISEmpEligibilities(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(EmployeeEligibility entity)
        {
            var result = await _httpClient.PostAsJsonAsync($"EmployeeEligibility", entity);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"EmployeeEligibility/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<EmployeeEligibility> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeEligibility>($"EmployeeEligibility/Find/{id}");
            return result;
        }

        public async Task<IEnumerable<EmpEligibilityVew>> GetAll(int employeeId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmpEligibilityVew>>("EmployeeEligibility/All?id=" + employeeId);
            return result;
        }

        public async Task<List<SelectListItems>> CscEligibility()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>("EmployeeEligibility/CscEligibilities");
            return result;
        }

        public async Task<CscEligibility> FincEligibility(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CscEligibility>($"EmployeeEligibility/FindCscEligibilities/{id}");
            return result;
        }

        public async Task<Response> Update(EmployeeEligibility entity)
        {
            var result = await _httpClient.PutAsJsonAsync("EmployeeEligibility/", entity);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();
        }
    }
}
