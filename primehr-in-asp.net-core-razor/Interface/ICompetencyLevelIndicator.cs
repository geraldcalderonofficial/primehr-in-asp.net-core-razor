using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICompetencyLevelIndicator
    {
        Task<IEnumerable<CompetencyLevelIndicatorView>> GetAll(int id);
        Task<IEnumerable<CompetencyLevelIndicatorView>> GetLevel(int id, string lvl);
        Task<List<CompetencyLevelIndicator>> Add(CompetencyLevelIndicator comp);
        Task<Response> Update(CompetencyLevelIndicator comp);
        Task<Response> Delete(int id);
    }
}
