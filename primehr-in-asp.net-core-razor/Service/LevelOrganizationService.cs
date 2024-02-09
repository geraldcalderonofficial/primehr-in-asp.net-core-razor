using System.Net.Http.Json;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;

namespace HRMSv4.Client.Service
{
    public class LevelOrganizationService : ILevelOrganization
    {
        private readonly HttpClient _httpClient;

        public LevelOrganizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LevelOrganization>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<LevelOrganization>>("LevelOrganization");
            return result;
        }

        public async Task<LevelOrganization> Get(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<LevelOrganization>($"LevelOrganization/{id}");
            return result;
        }

        public async Task<string> GetParentToChild(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<string>($"LevelOrganization/ParentToChild/{id}");
            return result;
        }

        public async Task<List<LevelOrganizationModelView>> GetByLevelTitle(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<LevelOrganizationModelView>>($"LevelOrganization/ByLevelTitle/{id}");
            return result;
        }

        public async Task<List<SelectListItems>> GetHighestLevel()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>("LevelOrganization/HighestLevel");
            return result;
        }

        public async Task<Response> Update(LevelOrganization lvlOrg)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<LevelOrganization>($"LevelOrganization", lvlOrg);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Add(LevelOrganization lvlOrg)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<LevelOrganization>($"LevelOrganization", lvlOrg);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"LevelOrganization/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<SelectListItems>> ListofParentLevels(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"LevelOrganization/ParentLevel/{id}");
            return result;
        }

        public async Task<List<SelectListItems>> ListofLevels(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"LevelOrganization/Sublevels/{id}");
            throw new NotImplementedException();
        }

        public async Task<List<SelectListItems>> GetDepartments(bool IsPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"LevelOrganization/Departments/{IsPlantilla}");
            return result;
        }

        public async Task<List<SelectListItems>> GetSubChildList(int id, int lvlId, bool IsPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"LevelOrganization/SubChildList/{id}/{lvlId}/{IsPlantilla}");
            return result;
        }

        public async Task<Response> GetLabelTitle(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>($"LevelOrganization/SubLabelTitle/{id}");
            return result;
        }
        public async Task<SetLevels> GetOrgLevels(int levelOrgId)
        {
            var result = await _httpClient.GetFromJsonAsync<SetLevels>("LevelOrganization/SelectedOrgLevels?levelOrgId=" + levelOrgId);
            return result;
        }
    }
}
