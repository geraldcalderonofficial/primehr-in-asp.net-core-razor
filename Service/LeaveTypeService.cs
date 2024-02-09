using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class LeaveTypeService : ILeaveType
    {
        private readonly HttpClient _httpClient;
        public LeaveTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<LeaveType>> GetLeaveTypes()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<LeaveType>>($"LeaveType/LeaveTypes");
            return result;
        }

        public async Task<LeaveType> GetLeaveType(int leaveTypeId)
        {
            var result = await _httpClient.GetFromJsonAsync<LeaveType>("LeaveType/GetLeaveType?leaveTypeId=" + leaveTypeId);
            return result;
        }

        public async Task<Response> AddLeaveType(LeaveType leaveType)
        {
            var result = await _httpClient.PostAsJsonAsync("LeaveType/AddLeaveType", leaveType);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> UpdateLeaveType(LeaveType leaveType)
        {
            var result = await _httpClient.PutAsJsonAsync($"LeaveType/UpdateLeaveType", leaveType);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteLeaveType(int leaveTypeId)
        {
            var result = await _httpClient.DeleteAsync($"LeaveType/DeleteLeaveType?leaveTypeId=" + leaveTypeId);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
        
    }
}
