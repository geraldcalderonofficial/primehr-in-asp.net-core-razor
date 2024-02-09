using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.Selection;

namespace HRMSv4.Client.Interface
{
    public interface ILeaveMonetization
    {
        Task<IQueryable<LeaveMonetization>> GetMonetizationList(string? status, DateTime? startDate, DateTime? endDate);
        Task<Response> RequestEmployeeCredit(MonetizedLeaveCredit requestedCredit);
        Task<Response> EditRequestEmployeeCredit(MonetizedLeaveCredit requestedCredit);
        Task<Response> ApproveRequestMonetization(MonetizedLeaveCredit requestedCredit);
        Task<MonetizationTotal> GetCurrentEmployeeCredits(int? employeeId);
        Task<LeaveMonetization> GetEmployeeRequestedMonetization(int? monetizedCreditId);
        Task<Response> DeleteRequestMonetization(int? monetizedCreditId);
    }
}
