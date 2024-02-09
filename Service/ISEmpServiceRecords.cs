using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpServiceRecords : IEmpServiceRecords
    {
        private readonly HttpClient _httpClient;
        public ISEmpServiceRecords(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceRecord>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceRecord> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServiceRecordListView>> GetServiceRecords(int employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceRecordListView>>($"EmployeeServiceRecords/ServiceRecords/{employeeId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<HttpResponseMessage> Insert(ServiceRecord entity)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Update(ServiceRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
