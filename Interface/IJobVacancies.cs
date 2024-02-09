using HRMSv4.Shared;
using HRMSv4.Shared.Exam;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IJobVacancies : IGenericRepository<JobVacancyView>
    {
        Task<IEnumerable<JobVacancyListView>> GetList(string IsPlantilla, string IsActive);
        Task<IEnumerable<JobVacancyListView>> GetListByEmployee(string IsPlantilla, int EmployeeId);
        Task<Response> ApplyMultiple(ApplyJobVacancy entity);
        Task<IEnumerable<PamApplicantsListview>> GetApplicantsByJobVacancy(int jobVacancyId);
        Task<JobPostingListView> JobPosts(int currentPage, int empStatus, int category, string exp, string search);
        Task<JobDetail> JobDetail(int jobVacancyId);
        Task<Response> TakeExam(ApplicantExamListView jl);
        Task<IEnumerable<Position>> GetOpenList(int orglvlId, bool isPlantilla);
        Task<IEnumerable<JobVacancyListView>> GetOrg(string pos);
        Task<Response> AutoCloseJobVacancy();
    }
}
