using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ApplicantEvaluationService : IApplicantEvaluation
    {
        private readonly HttpClient _httpClient;

        public ApplicantEvaluationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> AddQuestion(CrQuestionModel crq)
        {
            var result = await _httpClient.PostAsJsonAsync("ApplicantEvaluation/PostQuestion", crq);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> AddType(QuestionType category)
        {
            var result = await _httpClient.PostAsJsonAsync<QuestionType>("ApplicantEvaluation/PostType", category);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"ApplicantEvaluation/DeleteType?id="+id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteQuestion(int id)
        {
            var result = await _httpClient.DeleteAsync($"ApplicantEvaluation/DeleteQuestion?id=" + id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<IEnumerable<CrQuestionListView>> GetAllQuestion(int typeId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CrQuestionListView>>("ApplicantEvaluation/GetAllQuestion?typeId=" + typeId);
            return result;
        }

        public async Task<ApplicantEvaluationCount> GetCrDashboardCount()
        {
            var result = await _httpClient.GetFromJsonAsync<ApplicantEvaluationCount>($"ApplicantEvaluation/GetCrDashboardCount");
            return result;
        }

        public async Task<ApplicantEvaluationView> GetCrQuestions(int crqId, int currentPage, bool isNext, int empId, int characterRefId)
        {

            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApplicantEvaluationView>($"ApplicantEvaluation/GetQuestions?crqId=" + crqId + "&currentPage=" + currentPage + "&isNext=" + isNext + "&empId=" + empId + "&characterRefId=" + characterRefId);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<ApplicationEvaluationListView>> GetEvaluations()
        {
            var result = await _httpClient.GetFromJsonAsync< IEnumerable<ApplicationEvaluationListView>>($"ApplicantEvaluation/GetEvaluations");
            return result;
        }

        public async Task<CrQuestionModel> GetQuestion(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CrQuestionModel>($"ApplicantEvaluation/GetQuestion?id="+id);
            return result;
        }

        public async Task<QuestionType> GetType(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<QuestionType>($"ApplicantEvaluation/GetType/{id}");
            return result;
        }

        public async Task<IEnumerable<QuestionType>> GetTypes()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<QuestionType>>("ApplicantEvaluation/GetTypes");
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ApplicationEvaluationListView> PostStartEvaluation(int empId, int charReferenceId)
        {
            var result = await _httpClient.GetFromJsonAsync<ApplicationEvaluationListView>("ApplicantEvaluation/PostStartEvaluation?empId=" + empId + "&charReferenceId=" + charReferenceId);
            return result;
        }

        public async Task<HttpResponseMessage> SaveAnswer(CharacterReferenceQuestionnaireAnswer response)
        {
            var result = await _httpClient.PutAsJsonAsync("ApplicantEvaluation/PutAnswer/", response);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return result.EnsureSuccessStatusCode();
            }
            return null;
        }

        public async Task<Response> Update(QuestionType qt)
        {
            var result = await _httpClient.PutAsJsonAsync<QuestionType>($"ApplicantEvaluation/PutType", qt);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
