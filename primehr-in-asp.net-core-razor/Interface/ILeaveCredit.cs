using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;

namespace HRMSv4.Client.Interface
{
    public interface ILeaveCredit
    {
        Task<IQueryable<EarnedLeaveCreditListView>> GetEmployeeCreditList(int employeeId);
        Task<Response> AddLeaveCredit(EarnedLeaveCredit newCredit);
        Task<Response> UpdateLeaveCredit(EarnedLeaveCredit updateCredit);
        Task<List<DateTime>> GetEmployeeCreditDates(int employeeId);
        Task<EarnedLeaveCreditListView> GetEmployeeCredit(int creditId);
        Task<Response> DeleteLeaveCredit(int creditId);
    }
}
