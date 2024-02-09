using HRMSv4.Shared;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmpExperience
    {
        Task<IEnumerable<EmpExperienceView>> GetAll(int employeeId);
        Task<EmploymentExperience> Get(int id);
        Task<Response> Add(EmploymentExperience rel);
        Task<RateType> GetFindRate(int id);
        Task<List<SelectListItems>> RateType(string selected);
        Task<EmploymentStatus> GetFindStatus(int id);
        Task<List<SelectListItems>> Status();      
        Task<HttpResponseMessage> Delete(int id);
        Task<Response> Update(EmploymentExperience rel);
        Task<List<SelectListItems>> GetIndustry();
    }
}
