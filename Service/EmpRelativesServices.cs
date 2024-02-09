using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class EmpRelativesServices : IEmpRelatives
    {
        private readonly HttpClient _httpClient;


        public EmpRelativesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(EmployeeRelative rel)
        {
            var result = await _httpClient.PostAsJsonAsync("EmployeeRelatives", rel);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"EmployeeRelatives/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<EmployeeRelative> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeRelative>($"EmployeeRelatives/{id}");
            return result;
        }

        public async Task<IEnumerable<EmployeeRelative>> GetAll(int employeeId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeRelative>>($"EmployeeRelatives/All/{employeeId}");
            return result;
        }

        public async Task<HttpResponseMessage> isExists(string fullname, string birthdate)
        {
            var result = await _httpClient.GetFromJsonAsync<HttpResponseMessage>($"EmployeeRelatives/isExists/{fullname}/{birthdate}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode(); ;
        }

        public async Task<Response> Update(EmployeeRelative rel)
        {
            var result = await _httpClient.PutAsJsonAsync<EmployeeRelative>("EmployeeRelatives", rel);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();
        }
    }
}
