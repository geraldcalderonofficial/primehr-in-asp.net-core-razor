using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ILevelOrganization
    {
        Task<IEnumerable<LevelOrganization>> GetAll();
        Task<LevelOrganization> Get(long id);
        Task<List<LevelOrganizationModelView>> GetByLevelTitle(int id);
        Task<string> GetParentToChild(int id);
        Task<List<SelectListItems>> GetHighestLevel();
        Task<List<SelectListItems>> ListofParentLevels(int id);
        Task<List<SelectListItems>> ListofLevels(int id);
        Task<Response> Update(LevelOrganization lvlOrg);
        Task<Response> Add(LevelOrganization lvlOrg);
        Task<HRMSv4.Shared.Response> Delete(int id);
        Task<List<SelectListItems>> GetDepartments(bool IsPlantilla);
        Task<List<SelectListItems>> GetSubChildList(int id, int lvlId, bool IsPlantilla);
        Task<Response> GetLabelTitle(int id);
        Task<SetLevels> GetOrgLevels(int levelOrgId);
    }
}
