using DevExpress.XtraRichEdit.Model;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Pages.Modules;
using HRMSv4.Shared;
using HRMSv4.Shared.Exam;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class JobVacancyService : IJobVacancies
    {
        private readonly HttpClient _httpClient;
        public JobVacancyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"JobVacancy/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<JobVacancyView>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<JobVacancyView>>("JobVacancy/All?id=" + id);
            return result;
        }

        public async Task<IEnumerable<JobVacancyListView>> GetListByEmployee(string IsPlantilla, int EmployeeId)
         {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<JobVacancyListView>>("JobVacancy/GetAllForEmployee?IsPlantilla="+IsPlantilla+"&EmployeeId="+EmployeeId);
            return result; 
        }

        public async Task<IEnumerable<JobVacancyListView>> GetList(string IsPlantilla, string IsActive)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<JobVacancyListView>>($"JobVacancy/All/{IsPlantilla}/{IsActive}");
            return result;
        }

        public async Task<JobVacancyView> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<JobVacancyView>($"JobVacancy/{id}");
            return result;
        }

        public async Task<HttpResponseMessage> Insert(JobVacancyView entity)
        {
            var result = await _httpClient.PostAsJsonAsync($"JobVacancy", entity);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return result;
                //throw new Exception(await result.Content.ReadAsStringAsync());

            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Update(JobVacancyView entity)
        {
            var result = await _httpClient.PutAsJsonAsync<JobVacancyView>("JobVacancy/", entity);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<Response> ApplyMultiple(ApplyJobVacancy entity)
        {
            var result = await _httpClient.PostAsJsonAsync<ApplyJobVacancy>($"JobVacancy/ApplyMultiple", entity);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();

            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<IEnumerable<PamApplicantsListview>> GetApplicantsByJobVacancy(int jobVacancyId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamApplicantsListview>>($"JobVacancy/ApplicantsByJobVacancy/{jobVacancyId}");
            return result;
        }

        public async Task<JobPostingListView> JobPosts(int currentPage, int empStatus, int category, string exp, string search)
        {
            var result = await _httpClient.GetFromJsonAsync<JobPostingListView>("JobVacancy/JobPosts?currentPage=" + currentPage + "&empStatus=" + empStatus + "&category=" +  category + "&exp=" + exp + "&search=" + search);
            return result;
        }

        public async Task<JobDetail> JobDetail(int jobVacancyId)
        {
            var result = await _httpClient.GetFromJsonAsync<JobDetail>("JobVacancy/GetJobDetail?jobVacancyId=" + jobVacancyId);
            return result;
        }

        public async Task<Response> TakeExam(ApplicantExamListView jl)
        {
            var result = await _httpClient.PostAsJsonAsync("JobVacancy/PostTakeExam", jl);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<IEnumerable<Position>> GetOpenList(int orglvlId, bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Position>>($"JobVacancy/GetOpenPositionList?orglvlId="+ orglvlId + "&isPlantilla=" + isPlantilla);
            return result;
        }

        public async Task<IEnumerable<JobVacancyListView>> GetOrg(string pos)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<JobVacancyListView>>("JobVacancy/GetOrg?pos=" + pos);
            return result;
        }

        public async Task<Response> AutoCloseJobVacancy()
        {
            var result = await _httpClient.GetAsync("JobVacancy/AutoCloseJobVacancy");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
