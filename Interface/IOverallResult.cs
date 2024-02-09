using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;

namespace HRMSv4.Client.Interface
{
    public interface IOverallResult
    {
        Task<List<ScreeningCriteriaItem>> GetCriteriaItems();
        Task<Response> PostCriteriaItem(ScreeningCriteriaItem sci);
        Task<Response> PutCriteriaItem(ScreeningCriteriaItem sci);

        //overall
        Task<List<OverallResult>> GetOverallResult(int positionId);
    }
}
