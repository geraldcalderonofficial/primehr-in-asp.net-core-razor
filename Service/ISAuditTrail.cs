using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISAuditTrail : IAuditTrail
    {
        private readonly HttpClient _httpClient;
        public ISAuditTrail(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AuditLogView>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AuditLogView>>("AuditTrail/All");
            return result;
        }

        public async Task<List<AuditLogView>> GetByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AuditLogView>>("AuditTrail/GetByDate?fromDate=" + fromDate + "&toDate=" + toDate);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
