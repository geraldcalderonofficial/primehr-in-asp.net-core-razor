using DevExpress.XtraRichEdit.Model;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Shared.Modals.Premiums.wtaxContent;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.WebPages;

namespace HRMSv4.Client.Service
{
    public class ISLeaveMonetization : ILeaveMonetization
    {
        private readonly HttpClient _httpClient;

        public ISLeaveMonetization(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IQueryable<LeaveMonetization>> GetMonetizationList(string? status, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<LeaveMonetization>>($"LeaveMonetization/list?status=" + status + "&startDate=" + startDate + "&endDate=" + endDate);

                var queryableList = result.AsQueryable();

                return queryableList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> RequestEmployeeCredit(MonetizedLeaveCredit requestedCredit)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("LeaveMonetization", requestedCredit);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> EditRequestEmployeeCredit(MonetizedLeaveCredit requestedCredit)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("LeaveMonetization", requestedCredit);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MonetizationTotal> GetCurrentEmployeeCredits(int? employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<MonetizationTotal>($"LeaveMonetization/currentEmployeeCredits?employeeId=" + employeeId);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<LeaveMonetization> GetEmployeeRequestedMonetization(int? monetizedCreditId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<LeaveMonetization>($"LeaveMonetization/employeeRequestedMonetization?monetizedCreditId=" + monetizedCreditId);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> ApproveRequestMonetization(MonetizedLeaveCredit requestedCredit)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("LeaveMonetization/approveMonetization", requestedCredit);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> DeleteRequestMonetization(int? monetizedCreditId)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"LeaveMonetization?monetizedCreditId={monetizedCreditId}");
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
