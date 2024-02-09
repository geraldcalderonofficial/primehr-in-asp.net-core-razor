using HRMSv4.Client.Interface;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmployeeMasterList : IEmployeeMasterList
    {
        private readonly HttpClient _httpClient;
        public ISEmployeeMasterList(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IQueryable<EmployeeMasterListView>> All(EmployeeMasterListFilterView employee)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"EmployeeMasterList/All", employee);
                string res = await result.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<EmployeeMasterListView>>(res);
                var queryableList = list.AsQueryable();

                return queryableList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
