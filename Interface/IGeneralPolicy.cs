using HRMSv4.Client.Pages.Policy.Content;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.HrPolicy;

namespace HRMSv4.Client.Interface
{
    public interface IGeneralPolicy
    {
        Task<GeneralPolicy> Get();
        //Task<HttpResponseMessage> Add(GeneralPolicy cr);
        Task<Response> Add(GeneralPolicy cr);
        Task<GeneralPolicyListView> GetView();
        Task<HttpResponseMessage> AddJobApplication(JobApplicationPolicy jap);
        Task<JobApplicationPolicy> GetJobApplicationView();
        Task<List<int>> GetEmployeeUpdateList(int isPlantilla);
        Task<Response> UpdateSalaryGrade(EmployeeIdListView emp);
        Task<List<GeneralPolicyDateView>> GetPhilHealthDates();
        Task<List<GeneralPolicyDateView>> GetHdmfDates();
        Task<List<GeneralPolicyDateView>> GetSssDates();
        Task<List<GeneralPolicyDateView>> GetGsisDates();
        Task<List<GeneralPolicyDateView>> GetTaxDates();

        ///time log policy
        ///
        Task<TimeLogPolicy> GetTimeLogPolicy();
        Task<Response> PostTimeLogPolicy(TimeLogPolicy tl);

        /// applied premiums
        /// 
        Task<List<AppliedPremiumsPolicy>> GetPremiums();
        Task<Response> UpdateAppliedPremiums(AppliedPremiumsModel premiums);

        ///step increment
        ///
        Task<StepIncrementPolicy> GetStepIncrement();
        Task<Response> UpdateStepIncrement(StepIncrementPolicy inc);
    }
}
