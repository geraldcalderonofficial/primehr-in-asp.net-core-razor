using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared;

namespace HRMSv4.Client.Interface
{
    public interface IJobCategory
    {
        Task<IEnumerable<JobCategory>> GetAll();
        Task<JobCategory> Get(int id);
        Task<Response>Add(JobCategory category);
        Task<Response> Update(JobCategory category);
        Task<Response> Delete(int id);
        Task<List<JobCategoryListview>> GetPreview();
        Task<List<JobCategoryListview>> GetCategory();
        Task<List<JobCategoryListview>> GetFilter();
        Task<Response> GetCheckDuplicate(JobCategory category);
        Task<JobCategory> GetById(int id);
    }
}
