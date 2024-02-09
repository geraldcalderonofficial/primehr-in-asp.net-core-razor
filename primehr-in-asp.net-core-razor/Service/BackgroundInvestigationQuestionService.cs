using DevExpress.Blazor.Popup.Internal;
using DevExpress.Charts.Native;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Pages.Modules;
using HRMSv4.Shared;
using HRMSv4.Shared.Exam;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class BackgroundInvestigationQuestionService : IBackgroundInvestigationQuestion
    {
        private readonly HttpClient _httpClient;

        public BackgroundInvestigationQuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(BackgroundInvestigationQuestion bgq)
        {
            var result = await _httpClient.PostAsJsonAsync("BackgroundInvestigation", bgq);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"BackgroundInvestigation/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<BackgroundInvestigationQuestion> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<BackgroundInvestigationQuestion>($"BackgroundInvestigation/{id}");
            return result;
        }

        public async Task<IEnumerable<BackgroundInvestigationQuestion>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<BackgroundInvestigationQuestion>>("BackgroundInvestigation");
            return result;
        }

        public async Task<IEnumerable<ApplicantListView>> GetApplicants(int positionId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ApplicantListView>>($"BackgroundInvestigation/GetApplicants?positionId="+positionId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<BgItemsListView>> GetBgItems(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<BgItemsListView>>($"BackgroundInvestigation/GetQItems?bgId={id}");
            return result;
        }

        public async Task<List<InvestigationListView>> GetInvestigations()
        {
            var result = await _httpClient.GetFromJsonAsync<List<InvestigationListView>>($"BackgroundInvestigation/GetInvestigations");
            return result;
        }

        public async Task<IEnumerable<Position>> GetOpenPositions()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Position>>($"BackgroundInvestigation/GetOpenPositions");
            return result;
        }

        public async Task<BgQuestionView> GetQuestionItems(int id, int currentPage, bool isNext)
        {
            var result = await _httpClient.GetFromJsonAsync<BgQuestionView>($"BackgroundInvestigation/GetQuestionItems?id={id}&currentPage={currentPage}&isNext={isNext}");
            return result;
        }

        public async Task<ReportBg> PostReports(ReportBg rbg)
        {
            var result = await _httpClient.PostAsJsonAsync<ReportBg>($"BackgroundInvestigation/PostReports", rbg);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReportBg>(res);
        }

        public async Task<Response> PostBgInvestigation(InvestigationListView bi)
        {
            var result = await _httpClient.PostAsJsonAsync<InvestigationListView>($"BackgroundInvestigation/PostBgInvestigation", bi);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<HttpResponseMessage> PostItems(List<BgItemsListView> bgItems)
        {
            var result = await _httpClient.PostAsJsonAsync<List<BgItemsListView>>($"BackgroundInvestigation/PostItems", bgItems);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.EnsureSuccessStatusCode();
            }
            return null;
        }

        public async Task<HttpResponseMessage> SaveAnswer(BackgroundInvestigationItem response)
        {
            var result = await _httpClient.PutAsJsonAsync("BackgroundInvestigation/PutAnswer/", response);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.EnsureSuccessStatusCode();
            }
            return null;
        }

        public async Task<Response> Update(BackgroundInvestigationQuestion bgq)
        {
            var result = await _httpClient.PutAsJsonAsync<BackgroundInvestigationQuestion>($"BackgroundInvestigation", bgq);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        //public async Task<IEnumerable<BackgroundInvestigationQuestion>> 
    }
}
