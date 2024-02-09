using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;

namespace HRMSv4.Client.Interface
{
    public interface IApplicantCompetency
    {
        Task<List<CompetencyScoringView>> Get(int assessmentId, int posId, string compType);
        Task<IEnumerable<ApplicantListView>> GetApplicantsInterview(int status, string appStatus);
        Task<CompetencyAssessment> GetSelectedAssessment(int pamId);
        Task<Response> Add(CompetencyAssessment assessment);
        Task<Response> Update(CompetencyAssessmentItem assessmentItem);
        Task<List<CompetencyScoringView>> GetAssessmentResult(int assessmentId);
        Task<Response> SubmitAssessment(List<CompetencyScoringView> assessment);
        Task<List<AppliedJobsView>> GetJobApplied(int id);
    }
}
