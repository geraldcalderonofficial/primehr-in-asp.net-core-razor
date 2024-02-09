using HRMSv4.Client.Interface;
using HRMSv4.Shared.HrMgmt;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class LeaveTypeforModalService : ILeaveTypeforModal
    {
        private readonly HttpClient _httpClient;
        public LeaveTypeforModalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LeaveType> GetLeaveTypes(int leaveTypeId)
        {
            var result = await _httpClient.GetFromJsonAsync<LeaveType>("LeaveTypeforModal/GetLeaveTypeforModal=" + leaveTypeId);
            return result;
        }
    }
}
