using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class RoleService : IRole
    {
        private readonly HttpClient _httpClient;

       
        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(ApplicationRole role)
        {
            var result = await _httpClient.PostAsJsonAsync("role", role);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);

        }

        public async Task<Response> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync($"Role/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<ApplicationRole> Get(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApplicationRole>($"Role/{id}");
            return result;
        }

        public async Task<IEnumerable<ApplicationRole>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApplicationRole>>("Role");
            return result;
        }

        public async Task<Response> Update(ApplicationRole role)
        {
            var result = await _httpClient.PutAsJsonAsync<ApplicationRole>($"Role", role);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
