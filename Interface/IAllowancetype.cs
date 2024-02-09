using HRMSv4.Shared;
using HRMSv4.Shared.Payroll;
using DevExpress.DataAccess.Native.Web;

namespace HRMSv4.Client.Interface
{
    public interface IAllowancetype
    {
        public Task<List<AllowanceType>> GetAllowanceType(int id);
        public Task<Response> AddAllowanceType(AllowanceType allowanceType);
        public Task<Response> RemoveAllowanceType(int id);
        public Task<Response> UpdateAllowanceType(AllowanceType allowanceType);
        public Task<Response> GetUserData(int id);
        public Task<AllowanceType> Get(int id);
        public Task<IEnumerable<AllowanceType>> GetAll();
        Task<List<AllowanceType>> GetAllowFilter(int? id);
    }
}