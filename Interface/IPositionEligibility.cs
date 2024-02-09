using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPositionEligibility
    {
        Task<IEnumerable<PositionEligibilityViewModel>> GetAll();
        Task<PositionEligibilityViewModel> Get(int id);
        Task<IEnumerable<PositionEligibilityViewModel>> GetGet(int id);
        Task<List<PositionEligibilityViewModel>> Add(PositionEligibilityViewModel positionEligibility);
        Task<Response> Update(PositionEligibilityViewModel positionEligibility);
        Task<HRMSv4.Shared.Response> Delete(int id);
    }
}

