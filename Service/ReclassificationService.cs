
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ReclassificationService : IReclassification
    {
        private readonly HttpClient _httpClient;

        public ReclassificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Position>> GetAllPosition()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Position>>("Reclassification/GetAllPosition");
            return result;
        }

        public async Task<DateTime> GetEffectivityDate()
        {
            var result = await _httpClient.GetFromJsonAsync<DateTime>("Reclassification/GetEffectivityDate");
            return result;
        }

        public async Task<List<ReclassificationListView>> GetEmployeesReclassify(int positionId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ReclassificationListView>>("Reclassification/GetEmployeesReclassify?positionId="+positionId);
            return result;
        }

        public async Task<List<Position>> GetPlantillaPosition()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Position>>("Reclassification/GetPlantillaPosition");
            return result;
        }

        public async Task<Response> PostReclassification(ReclassificationDetail detail)
        {
            var result = await _httpClient.PostAsJsonAsync<ReclassificationDetail>("Reclassification/PostReclassification", detail);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
