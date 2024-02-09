using DevExpress.CodeParser;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.Payroll;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class LeavePolicyService : ILeavePolicy
    {
        private readonly HttpClient _httpClient;

        public LeavePolicyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> AddUpdateLeave(LeavePolicy lp)
        {
            var result = await _httpClient.PostAsJsonAsync("LeavePolicy/AddUpdateLeave", lp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> AddUpdateLeaveCredits(AnnualLeaveCredit credit)
        {
            var result = await _httpClient.PostAsJsonAsync("LeavePolicy/AddUpdateLeaveCredits", credit);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteLeaveCredits(int id)
        {
            var result = await _httpClient.DeleteAsync($"LeavePolicy/DeleteLeaveCredits?id=" + id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<AnnualLeaveCredit>> GetLeaveCredits()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AnnualLeaveCredit>>($"LeavePolicy/GetLeaveCredits");
            return result;
        }

        public async Task<LeavePolicyView> GetLeavePolicy()
        {
            var result = await _httpClient.GetFromJsonAsync<LeavePolicyView>($"LeavePolicy/GetLeavePolicy");
            return result;
        }

        public async Task<LeavePolicy> GetLeavePolicyId()
        {
            var result = await _httpClient.GetFromJsonAsync<LeavePolicy>($"LeavePolicy/GetLeavePolicyId");
            return result;
        }
    }
}
