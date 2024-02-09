using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ApplicantCompetencyService : IApplicantCompetency
    {
        private readonly HttpClient _httpClient;

        public ApplicantCompetencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CompetencyScoringView>> Get(int assessmentId, int posId, string compType)
        {
            var result = await _httpClient.GetFromJsonAsync<List<CompetencyScoringView>>($"ApplicantCompetency/All?assessmentId={assessmentId}&posId={posId}&compType={compType}");
            return result;
        }

        public async Task<List<CompetencyScoringView>> GetAssessmentResult(int assessmentId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<CompetencyScoringView>>($"ApplicantCompetency/AssessmentResult?assessmentId={assessmentId}");
            return result;
        }

        public async Task<CompetencyAssessment> GetSelectedAssessment(int pamId)
        {
            var result = await _httpClient.GetFromJsonAsync<CompetencyAssessment>($"ApplicantCompetency/SelectedAssessment?pamId={pamId}");
            return result;
        }

        public async Task<Response> Add(CompetencyAssessment assessment)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<CompetencyAssessment>($"ApplicantCompetency/AddAssessment", assessment);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Update(CompetencyAssessmentItem assessmentItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<CompetencyAssessmentItem>($"pplicantCompetency/UpdateAssessmentItem", assessmentItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> SubmitAssessment(List<CompetencyScoringView> assessment)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<List<CompetencyScoringView>>($"ApplicantCompetency/SubmitAssessment", assessment);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ApplicantListView>> GetApplicantsInterview(int status, string appStatus)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApplicantListView>>("ApplicantCompetency/GetApplications?status=" + status + "&appStatus=" + appStatus);
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
                var result = await _httpClient.GetFromJsonAsync<List<AppliedJobsView>>($"ApplicantCompetency/jobs/{id}");
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
