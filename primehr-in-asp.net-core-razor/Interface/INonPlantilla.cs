using HRMSv4.Shared;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface INonPlantilla
    {
        Task<IEnumerable<NonPlantillaRecordView>> GetNonPlantillaList(string sortBy, string arrangeBy, string orgId);
        Task<Response> Add(PositionItemView positionItem);
        Task<Response> Update(PositionItemView positionItem);
        Task<PositionItemView> Get(int id);
        Task<IEnumerable<Position>> GetOpenList();
        Task<Response> AbolishItem(int id, string userId);
    }
}
