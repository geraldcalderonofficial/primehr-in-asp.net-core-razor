using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;

namespace HRMSv4.Client.Interface
{
    public interface IReclassification
    {
        Task<List<Position>> GetPlantillaPosition();
        Task<List<Position>> GetAllPosition();
        Task<List<ReclassificationListView>> GetEmployeesReclassify(int positionId);
        Task<DateTime> GetEffectivityDate();
        Task<Response> PostReclassification(ReclassificationDetail detail);
    }
}
