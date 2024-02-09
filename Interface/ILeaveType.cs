using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;

namespace HRMSv4.Client.Interface
{
    public interface ILeaveType
    {
        Task<IEnumerable<LeaveType>> GetLeaveTypes();
        Task<LeaveType> GetLeaveType(int leaveTypeId);
        Task<Response> AddLeaveType(LeaveType leaveType);
        Task<Response> UpdateLeaveType(LeaveType leaveType);
        Task<Response> DeleteLeaveType(int leaveTypeId);
    }
}
