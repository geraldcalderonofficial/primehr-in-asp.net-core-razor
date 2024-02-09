using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using static HRMSv4.Shared.OnBoarding.EducationalAttainment;

namespace HRMSv4.Client.Interface
{
    public interface IEduAttainment
    {
        Task<IEnumerable<EducationalListview>> GetAll(int employeeId);
        Task<EducationalAttainment> Get(int id);
        Task<List<SelectListItems>> GetDegree(string level);
        Task<Response> Add(EducationalAttainment entity);
        Task<Response> Update(EducationalAttainment entity);
        Task<Response> Delete(int id);
        /* For Educational Attainment */
        Task<IEnumerable<EducationalAttainment>> LoadEducAttainment(int employeeId);
    }
}
