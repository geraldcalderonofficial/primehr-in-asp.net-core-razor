using DevExpress.DataAccess.Native.Web;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class PaperEvaluationService : IPaperEvaluation
    {
        private readonly HttpClient _httpClient;

        public PaperEvaluationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Add(PaperEvaluationTemplateItem temp)
        {
            var result = await _httpClient.PostAsJsonAsync($"PaperEvaluation", temp);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"PaperEvaluation/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<PaperEvaluationTemplateItem> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PaperEvaluationTemplateItem>($"PaperEvaluation/GetTemplateItem?id=" + id);
            return result;
        }

        public async Task<List<EvaluationApplicantListView>> GetApplicants(int positionId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<EvaluationApplicantListView>>($"PaperEvaluation/GetApplicants?positionId=" + positionId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<PaperEvaluation> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PaperEvaluation>($"PaperEvaluation/GetById?id=" + id);
            return result;

        }

        public async Task<EvaluationItemsListView> GetForEvaluation(int peId)
        {
            var result = await _httpClient.GetFromJsonAsync<EvaluationItemsListView>($"PaperEvaluation/GetForEvaluation?peId=" + peId);
            return result;
        }

        public async Task<IEnumerable<Position>> GetOpenPositions()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Position>>($"PaperEvaluation/GetOpenPositions");
            return result;
        }

        public async Task<IEnumerable<PaperEvaluationTemplateItem>> GetTemplateItems()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PaperEvaluationTemplateItem>>("PaperEvaluation/GetTemplateItems");
            return result;
        }

        public async Task<Response> PostApplicantEvaluation(PaperEvaluation pe)
        {
            var result = await _httpClient.PostAsJsonAsync<PaperEvaluation>($"PaperEvaluation/PostApplicantEvaluation", pe);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<HttpResponseMessage> PutPaperEvaluationItem(PaperEvaluationItemListView item)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("PaperEvaluation/PaperEvaluationItem", item);
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
                return result.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<HttpResponseMessage> Update(PaperEvaluationTemplateItem temp)
        {
            var result = await _httpClient.PutAsJsonAsync<PaperEvaluationTemplateItem>("PaperEvaluation/", temp);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PaperEvaluationItemSummaryReport>> GetPaperEvaluationItems(DateTime date)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PaperEvaluationItemSummaryReport>>($"PaperEvaluation/GetPaperEvaluationItems?date=" + date);
            return result;
        }


    }
}
