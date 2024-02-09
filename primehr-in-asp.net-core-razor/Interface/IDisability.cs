using HRMSv4.Client.Pages.Masterdata;
using HRMSv4.Shared;

namespace HRMSv4.Client.Interface
{
    public interface IDisability
    {
        Task<IEnumerable<HRMSv4.Shared.Masterdata.Disability>> GetAll();
        Task<HRMSv4.Shared.Masterdata.Disability> Get(int id);
        Task<Response> Add(HRMSv4.Shared.Masterdata.Disability dis);
        Task<Response> Update(HRMSv4.Shared.Masterdata.Disability dis);
        Task<Response> Delete(int id);
        Task<Response> GetCheckDuplicate(HRMSv4.Shared.Masterdata.Disability dis);
    }
}
