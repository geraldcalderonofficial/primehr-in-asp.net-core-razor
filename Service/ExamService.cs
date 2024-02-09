using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Exam;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace HRMSv4.Client.Service
{
    public class ExamService : IExam
    {
        private readonly HttpClient _httpClient;

        public ExamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region subject
        public async Task<Response> AddSubject(Subject subj)
        {
            var result = await _httpClient.PostAsJsonAsync<Subject>($"Exam/PostSubject", subj);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteSubject(int id)
        {
            var result = await _httpClient.DeleteAsync($"Exam/DeleteSubject/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res); throw new NotImplementedException();
        }

        public async Task<Subject> GetSubject(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Subject>($"Exam/GetSubject/{id}");
            return result;
        }

        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Subject>>("Exam/GetAllSubject");
            return result;
        }

        public async Task<Response> UpdateSubject(Subject subj)
        {
            var result = await _httpClient.PutAsJsonAsync<Subject>("Exam/PutSubject/", subj);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        #endregion
        #region exam

        public async Task<HttpResponseMessage> SaveEndedTime(TimerInfo data)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("exam/saveTimeended/", data);
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
                return result.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HttpResponseMessage> SaveStartTime(TimerInfo data)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("exam/savetimestarted/", data);
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
                return result.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<ExamListView>> GetAllExam(int examId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ExamListView>>("Exam/GetAllExam?examId=" + examId);
            return result;
        }

        public async Task<IEnumerable<ExamView>> GetAllExamOnly()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ExamView>>("Exam/GetAllExamOnly");
            return result;
        }

        public async Task<IEnumerable<string>> GetLevels()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<string>>("Exam/GetLevels");
            return result;
        }

        public async Task<Response> AddExamSubject(ExamAdd ea)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<ExamAdd>("Exam/SaveExamSubjects/", ea);
                //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
                //return result.EnsureSuccessStatusCode();
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res); throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Exam> GetExam(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Exam>("Exam/GetExam?id=" + id);
            return result;
        }

        public async Task<ExamListView> GetExamSubject(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ExamListView>("Exam/GetExamSubject?id=" + id);
            return result;
        }

        public async Task<HttpResponseMessage> EditExamSubject(ExamListView exsubj)
        {
            var result = await _httpClient.PutAsJsonAsync<ExamListView>("Exam/PutExamSubjEdit/", exsubj);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<List<ExamListView>> GetAllExamSubject(int examId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ExamListView>>("Exam/GetAllExamSubject?examId=" + examId);
            return result;
        }

        public async Task<HttpResponseMessage> DeleteExamSubject(int id)
        {
            var result = await _httpClient.DeleteAsync($"Exam/DeleteExamSubject?id=" + id);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> DeleteExam(int id)
        {
            var result = await _httpClient.DeleteAsync($"Exam/DeleteExam?id=" + id);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> UpdateExamSubjects(ExamAdd ea)
        {
            var result = await _httpClient.PutAsJsonAsync<ExamAdd>("Exam/UpdateExamSubjects/", ea);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
        public async Task<List<EmployeeExamView>> GetEmployeeExams(int empId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeExamView>>("Exam/GetEmployeeExams?empId=" + empId);
            return result;
        }

        public async Task<List<EmployeeExamView>> GetSubmittedExams(int empId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeExamView>>("Exam/GetSubmittedExams?empId=" + empId);
            return result;
        }

        #endregion
        #region question
        public async Task<IEnumerable<SubjectQuestion>> GetAllQuestions(int subjectId, string filter)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<SubjectQuestion>>("Exam/GetAllQuestions?subjectId=" + subjectId + "&filter=" + filter);
            return result;
        }

        public async Task<IEnumerable<string>> GetQuestionType()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<string>>("Exam/GetQuestionType");
            return result;
        }

        public async Task<Response> AddQuestion(SubjectQuestionView sq)
        {
            var result = await _httpClient.PostAsJsonAsync($"Exam/PostQuestion", sq);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res); throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> UpdateQuestion(SubjectQuestionView sq)
        {
            var result = await _httpClient.PutAsJsonAsync<SubjectQuestionView>("Exam/PutQuestion/", sq);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<Response> DeleteQuestion(int id)
        {
            var result = await _httpClient.DeleteAsync("Exam/DeleteQuestion?id=" + id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res); throw new NotImplementedException();
        }

        public async Task<Response> DeleteImage(int id, string image, int type, string updatedBy)
        {
            var result = await _httpClient.DeleteAsync("Exam/DeleteImage?id=" + id + "&image=" + image + "&type=" + type + "&updatedBy=" + updatedBy);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res); throw new NotImplementedException();
        }

        public async Task<SubjectQuestionView> GetQuestion(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SubjectQuestionView>($"Exam/GetQuestion?id=" + id);
            return result;
        }
        #endregion
        #region dashboard
        public async Task<DashboardCount> GetDashboardCount()
        {
            var result = await _httpClient.GetFromJsonAsync<DashboardCount>("Exam/GetDashboardCount");
            return result;
        }

        public async Task<DashboardChartOfExam> GetChartOfExams()
        {
            var result = await _httpClient.GetFromJsonAsync<DashboardChartOfExam>("Exam/GetChartOfExams");
            return result;
        }

        public async Task<DashboardChartOfUser> GetChartOfUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<DashboardChartOfUser>("Exam/GetChartOfUsers");
            return result;
        }

        public async Task<DashboardGenderStatistics> GetGenderStatistics()
        {
            var result = await _httpClient.GetFromJsonAsync<DashboardGenderStatistics>("Exam/GetGenderStatistics");
            return result;
        }

        public async Task<List<DashboardTopRank>> GetTopRank()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DashboardTopRank>>("Exam/GetTopRank");
            return result;
        }

        public async Task<List<DashboardRecentExaminees>> GetRecentExaminees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DashboardRecentExaminees>>("Exam/GetRecentExaminees");
            return result;
        }

        #endregion 
        #region Questionaire
        public async Task<List<ExamQuesionListView>> GetApplicantExam(int ApplicantExamId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ExamQuesionListView>>("Exam/GetApplicantExam");
            return result;
        }

        //public async Task<PagedList<ExamQuesionListView>> GetProducts(Parameters _parameters)
        //{
        //    var result = await _httpClient.GetFromJsonAsync<PagedList<ExamQuesionListView>>("/api/Exam/GetApplicantExam");
        //    return result;
        //}

        public async Task<QuestionQueueView> GetApplicantExam(int ApplicantExamId, int currentPage, bool isNext, bool isSkip)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<QuestionQueueView>($"Exam/GetApplicantExam?ApplicantExamId={ApplicantExamId}&currentPage={currentPage}&isNext={isNext}&isSkip={isSkip}");
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        public async Task<ExamResults> ShowResults(int ApplicantExamId, string userId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ExamResults>($"exam/exam-results?ApplicantExamId={ApplicantExamId}&userId={userId}");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> SaveAns(ApplicantExamAnswer response)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("exam/putanswer/", response);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return result.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        public async Task<ApplicantExamStatistics> GetApplicantStat(int _examId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApplicantExamStatistics>($"Exam/ExamStatistics?ExamId={_examId}");
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        public async Task<ExamStatistics> GetExamStatistic(int ApplicantExamId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ExamStatistics>($"Exam/GetExamStatistic?ApplicantExamId={ApplicantExamId}");
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        public async Task<HttpResponseMessage> BeginExam(SelectedApplicantExamView applicantExam)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("Exam/BeginExam/", applicantExam);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return result.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        #endregion

        #region results

        public async Task<List<ApplicantResultListView>> GetApplicantExamResultList(int positionId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ApplicantResultListView>>("Exam/GetApplicantExamResultList?positionId=" + positionId);
            return result;
        }

        public async Task<ApplicantResultAnswersListView> GetApplicantAnswers(int applicantExamId)
        {
            var result = await _httpClient.GetFromJsonAsync<ApplicantResultAnswersListView>("Exam/GetApplicantAnswers?applicantExamId=" + applicantExamId);
            return result;
        }

        public async Task<List<HRMSv4.Shared.OnBoarding.Position>> GetExamPosition()
        {
            var result = await _httpClient.GetFromJsonAsync<List<HRMSv4.Shared.OnBoarding.Position>>("Exam/GetExamPosition");
            return result; 
        }

        public async Task<HttpResponseMessage> UpdateApplicantExam(SelectedApplicantExamView selectedApplicantExamView)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("Exam/ApplicantExamDone/", selectedApplicantExamView);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return result.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        public async Task<Response> PutEssayScore(ApplicantAnswers ans)
        {
            var result = await _httpClient.PutAsJsonAsync($"Exam/PutEssayScore", ans);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res); throw new NotImplementedException();
        }

        #endregion
    }
}
