using Blazored.LocalStorage;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISLeaveCredit : ILeaveCredit
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IHttpContextAccessor _context;
        private readonly NavigationManager _nav;
        public ISLeaveCredit(HttpClient httpClient, ILocalStorageService localStorage, IHttpContextAccessor context, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _context = context;
            _nav = navigationManager;
        }

        public async Task<Response> AddLeaveCredit(EarnedLeaveCredit newCredit)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"LeaveCredit", newCredit);
                string response =  await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(response);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> DeleteLeaveCredit(int creditId)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"LeaveCredit?creditId={creditId}");
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<EarnedLeaveCreditListView>> GetEmployeeCreditList(int employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EarnedLeaveCreditListView>>($"LeaveCredit?employeeId={employeeId}");

                var queryList = result.AsQueryable();

                return queryList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<DateTime>> GetEmployeeCreditDates(int employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<DateTime>>($"LeaveCredit/employeeCreditDates?employeeId={employeeId}");

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EarnedLeaveCreditListView> GetEmployeeCredit(int creditId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<EarnedLeaveCreditListView>($"LeaveCredit/selectedCreditDate?creditId={creditId}");

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> UpdateLeaveCredit(EarnedLeaveCredit updateCredit)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"LeaveCredit", updateCredit);
                string response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(response);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
