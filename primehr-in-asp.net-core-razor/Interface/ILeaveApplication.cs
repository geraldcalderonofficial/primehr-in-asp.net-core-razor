using DevExpress.DataAccess.Native.Web;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using Microsoft.AspNetCore.Http;

namespace HRMSv4.Client.Interface
{
    public interface ILeaveApplication
    {
        Task<List<LeaveApplicationView>> GetLeaveApplications(string status, DateTime? Start, DateTime? End, int Id);
        Task<LeaveApplicationView> GetLeaveApplication(int leaveApplicationId);
        Task<Response> AddLeaveApplication(LeaveApplicationView leaveApplication);
        Task<Response> UpdateLeaveApplication(LeaveApplicationView leaveApplication);
        Task<Response> DeleteLeaveApplication(int leaveApplicationId);
        Task<Response> PatchApplication(LeaveApplicationView item);
    }
}
