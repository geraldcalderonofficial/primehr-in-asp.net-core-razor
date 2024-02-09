using HRMSv4.Client.Interface;
using HRMSv4.Shared.HrMgmt;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class LeaveDashboardService : ILeaveDashboard
    {
        private readonly HttpClient _httpClient;
        public LeaveDashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DashboardLeaveCount> GetCount()
        {
            var result = await _httpClient.GetFromJsonAsync<DashboardLeaveCount>($"Leave/GetCount");
            return result;
        }

        public async Task<List<LeaveApplicationView>> GetLatestRequests()
        {
            var result = await _httpClient.GetFromJsonAsync<List<LeaveApplicationView>>($"Leave/GetLatestRequests");
            return result;
        }

        public async Task<List<DashboardNextSevenDays>> GetNextSevenDays()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DashboardNextSevenDays>>($"Leave/GetNextSevenDays");
            return result;
        }
    }
}
