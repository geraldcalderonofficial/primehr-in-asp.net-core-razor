using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmpEligibilities
    {
        Task<IEnumerable<EmpEligibilityVew>> GetAll(int employeeId);
        Task<EmployeeEligibility> Get(int id);
        Task<List<SelectListItems>> CscEligibility();
        Task<Response> Add(EmployeeEligibility entity);
        Task<Response> Update(EmployeeEligibility entity);
        Task<HttpResponseMessage> Delete(int id);
        Task<CscEligibility> FincEligibility(int id);
    }
}
