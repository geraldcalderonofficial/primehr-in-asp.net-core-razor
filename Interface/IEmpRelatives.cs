using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmpRelatives
    {
        Task<IEnumerable<EmployeeRelative>> GetAll(int employeeId);
        Task<Response> Add(EmployeeRelative rel);
        Task<EmployeeRelative> Get(int id);
        Task<HttpResponseMessage> isExists(string fullname, string birthdate);
        Task<HttpResponseMessage> Delete(int id);
        Task<Response> Update(EmployeeRelative rel);
    }
}
