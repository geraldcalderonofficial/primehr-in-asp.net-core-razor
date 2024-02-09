using HRMSv4.Client.Interface;
using HRMSv4.Shared.Timekeeping;
using static HRMSv4.Shared.OnBoarding.EducationalAttainment;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpScheduleLog : IEmpScheduleLog
    {
        private readonly HttpClient _httpClient;
        public ISEmpScheduleLog(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<EmployeeScheduleLog>> GetAll(int employeeId, DateTime date)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<EmployeeScheduleLog>>("EmployeeScheduleLog/GetScheduleLogs?employeeId=" + employeeId + "&date=" + date);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
