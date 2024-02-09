using HRMSv4.Shared.HrMgmt;

namespace HRMSv4.Client.Interface
{
    public interface ILeaveDashboard
    {
        Task<DashboardLeaveCount> GetCount();
        Task<List<LeaveApplicationView>> GetLatestRequests();
        Task<List<DashboardNextSevenDays>> GetNextSevenDays();

    }
}
