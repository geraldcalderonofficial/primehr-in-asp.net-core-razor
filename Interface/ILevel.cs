using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ILevel
    {
        Task<IEnumerable<Level>> GetAll();
        Task<List<Level>> Add(Level lvl);
        Task<Response> Update(Level lvl);
        Task<HRMSv4.Shared.Response> Delete(int id);
        Task<Level> Get(long id);
        Task<string> GetLabel();
        Task<List<SelectListItems>> ListofChildLevels(int id);
        Task<SetLevels> GetLevels(int levelId);
        Task<int> GetChildLevelsCount(int levelId);
        Task<List<ParentChildLevel>> ParentToChildLevels();
    }
}
