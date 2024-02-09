using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmploymentStatus
    {
        Task<IEnumerable<EmploymentStatus>> GetAll();
        Task<EmploymentStatus> Get(int id);
        Task<IEnumerable<EmploymentStatus>> Get(bool isPlantilla);
        Task<Response> Add(EmploymentStatus status);
        Task<Response> Update(EmploymentStatus status);
        Task<Response> Delete(int id);
        Task<IEnumerable<EmploymentStatusListview>> GetFilter();
        Task<Response> GetCheckDuplicate(EmploymentStatus status);
    }
}
