using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.StoredProcedure;

namespace HRMSv4.Client.Interface
{
    public interface IRecruitmentPlan
    {

        //recruitment plan
        Task<List<RecruitmentPlanListView>> GetRecruitmentPlans();
        Task<Response> PostRecruitmentPlans(RecruitmentPlan rp);
        Task<RecruitmentPlan> GetRecruitmentPlanById(int id);


        //recruitment approach
        Task<List<RecruitmentApproach>> GetRecruitmentApproach(int rpId);
        Task<Response> PostRecruitmentApproaches(RecruitmentApproach plan);
        Task<Response> DeleteRecruitmentApproach(int id);

        //recruitment targets
        Task<List<TargetVacantPositionListView>> GetTargets(int rpId);
        Task<Response> CreateTargets(TargetCreateModel tcm);
        Task<Response> UpdateTarget(TargetVacantPositionListView tp);

        //recruitment candidates
        Task<List<PossibleCandidateListView>> GetCandidateApplicants(int id, string userId);
    }
}
