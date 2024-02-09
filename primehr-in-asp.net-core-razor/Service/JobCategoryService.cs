using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class JobCategoryService : IJobCategory
    {
        private readonly HttpClient _httpClient;

        public JobCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(JobCategory category)
        {
            var result = await _httpClient.PostAsJsonAsync("JobCategory", category);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"JobCategory/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
        
        public async Task<JobCategory> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<JobCategory>($"JobCategory/{id}");
            return result;
        }

        public async Task<IEnumerable<JobCategory>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<JobCategory>>("JobCategory");
            return result;
        }

        public async Task<List<JobCategoryListview>> GetPreview()
        {
            var result = await _httpClient.GetFromJsonAsync<List<JobCategoryListview>>("JobCategory");
            return result;
        }

        public async Task<Response> Update(JobCategory category)
        {
            var result = await _httpClient.PutAsJsonAsync<JobCategory>($"JobCategory", category);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<JobCategoryListview>> GetCategory()
        {
            var result = await _httpClient.GetFromJsonAsync<List<JobCategoryListview>>("JobCategory/CategoryPreview");
            return result;
        }

        public async Task<List<JobCategoryListview>> GetFilter()
        {
            var result = await _httpClient.GetFromJsonAsync<List<JobCategoryListview>>("JobCategory/GetFilter");
            return result;
        }

        public async Task<Response> GetCheckDuplicate(JobCategory category)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"JobCategory/CheckDuplicate", category);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<JobCategory> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<JobCategory>("JobCategory/GetById?id="+id);
            return result;
        }
        //void IJobCategory.Update(JobCategory entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
