using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICourse
    {
        Task<IEnumerable<Course>> GetAll();
        Task<IEnumerable<Course>> GetBachelors();
        Task<IEnumerable<Course>> GetVocational();
        Task<IEnumerable<Course>> GetMasters();
        Task<IEnumerable<Course>> GetDoctorate();
        Task<Course> Get(int id);
        Task<Response> Add(Course course);
        Task<Response> Update(Course course);
        Task<Response> Delete(int id);
        Task<Response> GetCheckDuplicate(Course course);
    }
}
