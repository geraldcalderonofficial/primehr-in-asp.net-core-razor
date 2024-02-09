using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.Payroll;

namespace HRMSv4.Client.Interface
{
    public interface ILeavePolicy
    {
        Task<List<AnnualLeaveCredit>> GetLeaveCredits();
        Task<Response> AddUpdateLeaveCredits(AnnualLeaveCredit credit);
        Task<Response> DeleteLeaveCredits(int id);

        Task<LeavePolicyView> GetLeavePolicy();
        Task<LeavePolicy> GetLeavePolicyId();
        Task<Response> AddUpdateLeave(LeavePolicy lp);
    }
}
