using HRMSv4.Shared;

namespace HRMSv4.Client.Interface
{
    public interface IRole
    {
        Task<IEnumerable<ApplicationRole>> GetAll();
        Task<Response> Add(ApplicationRole role);
        Task<ApplicationRole> Get(string id);
        Task <Response> Delete(string id);
        Task<Response> Update(ApplicationRole role);
    }
}
