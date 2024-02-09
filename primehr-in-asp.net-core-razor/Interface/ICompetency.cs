using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICompetency
    {
        Task<IEnumerable<Competency>> GetAll();
        Task<Competency> Get(long id);
        Task<List<Competency>> Add(Competency comp);
        Task<Response> Update(Competency comp);
        Task<Response> Delete(int id);
        Task<Response> LevelList(CompetencyLevelViewList lvl);
    }
}
