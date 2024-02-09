using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using DevExpress.DataAccess.Native.Web;

namespace HRMSv4.Client.Interface
{
    public interface ILocatorSlip
    {
        public Task<List<LocatorSlipView>> GetLocatorSlip(string status, DateTime? Start, DateTime? End, int Id);
        public Task<List<LocatorSlip>> GetLocatorSlipDetails();
        public Task<Response> AddLocatorSlip(LocatorSlip locatorSlip);
        public Task<Response> DeleteLocatorSlip(int id);
        public Task<Response> UpdateLocatorSlip(LocatorSlip locatorSlip);
        public Task<Response> GetUserData(int id);
        public Task<Response> accept(LocatorSlipView locatorSlip);
        public Task<bool> ValidateLocatorSlipNo(int empId, DateTime? dtFrom, DateTime? to, string type);
    }
}
