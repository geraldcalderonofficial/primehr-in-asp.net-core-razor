using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISApplicants : IApplicants
    {
        private readonly HttpClient _httpClient;
        public ISApplicants(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ApplicantListView>> GetApplicants(string status)
        {
            try
            {
                //var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApplicantListView>>($"/api/Applicant?status={status}");
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApplicantListView>>($"Applicant/All/{status}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<ApplicantListView>> GetApplications(int status, string appStatus)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApplicantListView>>("Applicant/GetApplications?status=" + status + "&appStatus=" + appStatus);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<ApplicantDetailView> GetApplicantDetails(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApplicantDetailView>($"Applicant/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<AppliedJobsView>> GetJobApplied(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AppliedJobsView>>($"Applicant/jobs/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        
    }
}
