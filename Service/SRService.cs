using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class SRService : IServiceRecord
    {
        private readonly HttpClient _httpClient;
        public SRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceRecord> LatestServiceRecords(int empId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceRecord>($"ServiceRecord/GetLatestServiceRecord/{empId}");
            return result;
        }

        public async Task<IEnumerable<ServiceRecordListView>> ListofServiceRecords(int empId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceRecordListView>>($"ServiceRecord/GetAllService/{empId}");
            return result;
        }

        public async Task<bool> StepIncrementQualification(int empId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<bool>($"ServiceRecord/GetStepIncrementQualification/{empId}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
