using HRMSv4.Client.Interface;
using HRMSv4.Client.Interface.Payroll;
using HRMSv4.Shared.Payroll;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpPremium : IEmpPremium
    {
        private readonly HttpClient _httpClient;
        public ISEmpPremium(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeePremiumView>> GetPremiums(int employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<EmployeePremiumView>>($"EmployeePremiums/GetPremiums/{employeeId}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }
    }
}
