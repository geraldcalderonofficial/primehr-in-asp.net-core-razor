using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmpComService : IGenericRepository<EmployeeCommunityService>
    {
        Task<IEnumerable<EmployeeCommunityListView>> GetAll(int id);
        Task<Response> Add(EmployeeCommunityService entity);
        Task<Response> Put(EmployeeCommunityService entity);
    }
}
