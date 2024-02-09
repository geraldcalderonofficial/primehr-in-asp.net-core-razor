using HRMSv4.Shared;
using HRMSv4.Shared.HrPolicy;

namespace HRMSv4.Client.Interface
{
    public interface IMultiplier
    {
        Task<IQueryable<MultiplierView>> GetAll();
        Task<Response> Insert(MultiplierView item);
        Task<Response> Update(MultiplierView item);
        Task <Response> Delete(int id);

    }
}
