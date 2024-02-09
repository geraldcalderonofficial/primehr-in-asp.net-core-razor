using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPosition
    {
        Task<IEnumerable<PositionListViewModel>> GetAll();
        Task<PositionListViewModel> Get(int id);
        Task<Response> Add(PositionListViewModel category);
        Task<Response> Update(PositionListViewModel category);
        Task<HRMSv4.Shared.Response> Delete(int id);
        Task<Response> PositionQualifications(PositionQualificationList position);
        Task<IEnumerable<PositionListViewModel>> GetPositionsWithSg(bool isPlantilla);
        Task<IEnumerable<PositionListViewModel>> GetEmpPosition(string name);
        Task<Position> GetPositionById(int id);
    }
}
