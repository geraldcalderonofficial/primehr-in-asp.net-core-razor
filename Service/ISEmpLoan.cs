using HRMSv4.Client.Interface;
using HRMSv4.Client.Interface.Payroll;
using HRMSv4.Shared;
using HRMSv4.Shared.Payroll;
using HRMSv4.Shared.Timekeeping;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpLoan : IEmpLoan
    {
        private readonly HttpClient _httpClient;
        public ISEmpLoan(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeLoanView>> GetAll(int employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<EmployeeLoanView>>($"EmployeeLoan/GetLoans/{employeeId}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
