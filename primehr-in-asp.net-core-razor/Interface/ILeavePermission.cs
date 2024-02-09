using DevExpress.DataAccess.Native.Web;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;

namespace HRMSv4.Client.Interface
{
    public interface ILeavePermission
    {
        Task<IQueryable<LeavePermissionView>> All(string status, DateTime? Start, DateTime? End, int Id);
        Task<Response> Insert(LeavePermissionView item);
        Task<Response> Update(LeavePermissionView item);
        Task<Response> Delete(int id);
        Task<Response> Find(int id);
        Task<Response> Save(LeavePermissionView item);
        Task<Response> Patch(LeavePermissionView item);

    }
}
