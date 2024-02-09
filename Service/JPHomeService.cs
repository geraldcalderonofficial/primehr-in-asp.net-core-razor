using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class JPHomeService : IJpHome
    {
        private readonly HttpClient _httpClient;

        public JPHomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<JobCategoryDashboardListView>> GetCategory()
        {
            var result = await _httpClient.GetFromJsonAsync<List<JobCategoryDashboardListView>>("JPHome");
            return result;
        }
    }
}
