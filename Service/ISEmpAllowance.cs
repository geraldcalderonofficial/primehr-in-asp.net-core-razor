using HRMSv4.Client.Interface;
using HRMSv4.Client.Interface.Payroll;
using HRMSv4.Shared;
using HRMSv4.Shared.Payroll;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpAllowance : IEmpAllowance
    {
        private readonly HttpClient _httpClient;
        public ISEmpAllowance(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeAllowanceView>> GetAllowances(int employeeId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeAllowanceView>>($"EmployeeAllowance/GetAllowances/{employeeId}");
            return result;
        }
    }
}
