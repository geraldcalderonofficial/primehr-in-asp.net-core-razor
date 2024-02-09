using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IApplicants
    {

        Task<IEnumerable<ApplicantListView>> GetApplicants(string status);
        Task<IEnumerable<ApplicantListView>> GetApplications(int status, string appStatus);
        Task<ApplicantDetailView> GetApplicantDetails(int id);
        Task<List<AppliedJobsView>> GetJobApplied(int id);
    }
}
