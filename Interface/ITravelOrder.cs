using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;

namespace HRMSv4.Client.Interface
{
    public interface ITravelOrder
    {
        Task<Response> Delete(int id);
        Task<Response> Add(TravelOrderList item);
        Task<List<TravelOrder>> GetAll();
        Task<List<TravelOrderEmployee>> GetAllEmpById(int id, bool isEmployee);
    }
}
