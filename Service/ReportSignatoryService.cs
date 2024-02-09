using HRMSv4.Client.Interface;
using HRMSv4.Client.Pages.Modules;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Report;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ReportSignatoryService : IReportSignatory
    {
        private readonly HttpClient _httpClient;
        public ReportSignatoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReportSignatoryView>> GetReportSignatories(string reportName, string? purpose)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<ReportSignatoryView>>("ReportSignatory/GetReportSignatories?reportName=" + reportName + "&purpose=" + purpose);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<ReportSignatoryView> GetReportSignatory(string reportName, string purpose, string? signatoryName)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ReportSignatoryView>("ReportSignatory/GetReportSignatory?reportName=" + reportName + "&purpose=" + purpose + "&signatoryName=" + signatoryName);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Response> AddReportSignatory(ReportSignatoryView signatory)
        {
            var result = await _httpClient.PostAsJsonAsync($"ReportSignatory/AddReportSignatory", signatory);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> UpdateReportSignatory(ReportSignatoryView signatory)
        {
            var result = await _httpClient.PutAsJsonAsync($"ReportSignatory/UpdateReportSignatory", signatory);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteReportSignatory(int id)
        {
            var result = await _httpClient.DeleteAsync($"ReportSignatory/DeleteReportSignatory/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
