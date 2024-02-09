using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;


namespace HRMSv4.Client.Service
{
    public class ProfileUpdateService : IProfileUpdate
    {
        private readonly HttpClient _httpClient;

        public ProfileUpdateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response> Add(ProfileUpdate request)
        {
            var result = await _httpClient.PostAsJsonAsync("ProfileUpdate", request);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<ProfileUpdateView> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ProfileUpdateView>($"ProfileUpdate/{id}");
            return result;
        }
    }
}
