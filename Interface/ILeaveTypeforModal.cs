using HRMSv4.Shared.HrMgmt;

namespace HRMSv4.Client.Interface
{
    public interface ILeaveTypeforModal
    {
        Task<LeaveType> GetLeaveTypes(int leaveTypeId);
    }
}
