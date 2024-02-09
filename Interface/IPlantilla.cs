using HRMSv4.Shared;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPlantilla
    {
        Task<IEnumerable<PlantillaRecordView>> GetPlantillaList(string sortBy, string arrangeBy, string orgId);
        Task<Response> Add(PositionItemView positionItem);
        Task<Response> Update(PositionItemView positionItem);
        Task<IEnumerable<PositionItem>> GetAll();
        Task<Response> CheckPlantilla();
        Task<Response> PlantillaYear(string id);
        Task<PositionItemView> Get(int id);
        Task<Response> GetCheckSelectedPlantilla(int positionItemId);
        //Task<Response> AbolishItem(PlantillaRecordView positionItem);
        Task<Response> AbolishItem(PositionItem positionItem);
        Task<IEnumerable<PositionItemList>> GetOpenPositionItem(int organizationId, int positionId, bool isPlantilla);
        Task<Response> PassList(List<PlantillaRecordView> positionItem, int id);
        Task<Response> TempPlantilla(PlantillaRecordView positionItem);
        Task<IEnumerable<PlantillaSearchView>> SearchPlantilla(int salaryGrade, int takRequest);
        Task<IEnumerable<Position>> GetOpenList();
    }
}
