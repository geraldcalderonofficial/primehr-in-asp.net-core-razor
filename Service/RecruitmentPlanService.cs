using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.StoredProcedure;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
using System.Reactive.Joins;

namespace HRMSv4.Client.Service
{
    public class RecruitmentPlanService : IRecruitmentPlan
    {
        private readonly HttpClient _httpClient;
        public RecruitmentPlanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> DeleteRecruitmentApproach(int id)
        {
            var result = await _httpClient.DeleteAsync("AnnualRecruitmentPlan/DeleteRecruitmentApproach?id=" +id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<RecruitmentApproach>> GetRecruitmentApproach(int rpId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<RecruitmentApproach>>($"AnnualRecruitmentPlan/GetRecruitmentApproach?rpId=" + rpId);
            return result;
        }

        public async Task<RecruitmentPlan> GetRecruitmentPlanById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<RecruitmentPlan>($"AnnualRecruitmentPlan/GetRecruitmentPlanById?id=" + id);
            return result;
        }

        public async Task<List<RecruitmentPlanListView>> GetRecruitmentPlans()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RecruitmentPlanListView>>($"AnnualRecruitmentPlan/GetRecruitmentPlans");
            return result;
        }

        public async Task<List<TargetVacantPositionListView>> GetTargets(int rpId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<TargetVacantPositionListView>>($"AnnualRecruitmentPlan/GetTargets?rpId=" + rpId);
            return result;
        }

        public async Task<Response> PostRecruitmentApproaches(RecruitmentApproach plan)
        {
            var result = await _httpClient.PostAsJsonAsync<RecruitmentApproach>($"AnnualRecruitmentPlan/PostRecruitmentApproaches", plan);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> CreateTargets(TargetCreateModel tcm)
        {
            var result = await _httpClient.PostAsJsonAsync<TargetCreateModel>($"AnnualRecruitmentPlan/CreateTargets", tcm);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> PostRecruitmentPlans(RecruitmentPlan rp)
        {
            var result = await _httpClient.PostAsJsonAsync<RecruitmentPlan>($"AnnualRecruitmentPlan/PostRecruitmentPlans", rp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> UpdateTarget(TargetVacantPositionListView tp)
        {
            var result = await _httpClient.PutAsJsonAsync<TargetVacantPositionListView>($"AnnualRecruitmentPlan/UpdateTarget", tp);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<PossibleCandidateListView>> GetCandidateApplicants(int id, string userId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PossibleCandidateListView>>($"AnnualRecruitmentPlan/GetPossibleCandidates?id=" + id + "&userId=" + userId);
            return result;
        }
    }
}
