using HRMSv4.Client.Pages.Masterdata;
using HRMSv4.Shared;
using HRMSv4.Shared.Exam;

namespace HRMSv4.Client.Interface
{
    public interface IExam
    {
        //dashboard
        Task<DashboardCount> GetDashboardCount();
        Task<DashboardChartOfExam> GetChartOfExams();
        Task<DashboardChartOfUser> GetChartOfUsers();
        Task<DashboardGenderStatistics> GetGenderStatistics();
        Task<List<DashboardTopRank>> GetTopRank();
        Task<List<DashboardRecentExaminees>> GetRecentExaminees();

        //subjects
        Task<IEnumerable<Subject>> GetAllSubject();
        Task<Subject> GetSubject(int id);
        Task<Response> AddSubject(Subject subj);
        Task<Response> UpdateSubject(Subject subj);
        Task<Response> DeleteSubject(int id);

        //exams
        Task<HttpResponseMessage> SaveStartTime(TimerInfo data);
        Task<HttpResponseMessage> SaveEndedTime(TimerInfo data);

        Task<IEnumerable<ExamView>> GetAllExamOnly();
        Task<IEnumerable<ExamListView>> GetAllExam(int examId);
        Task<IEnumerable<string>> GetLevels();
        Task<Response> AddExamSubject(ExamAdd ea);
        Task<Exam> GetExam(int id);
        Task<ExamListView> GetExamSubject(int id);
        Task<HttpResponseMessage> EditExamSubject(ExamListView exsubj);
        Task<List<ExamListView>> GetAllExamSubject(int examId);
        Task<HttpResponseMessage> DeleteExamSubject(int id);
        Task<HttpResponseMessage> DeleteExam(int id);
        Task<HttpResponseMessage> UpdateExamSubjects(ExamAdd ea);
        Task<List<EmployeeExamView>> GetEmployeeExams(int empId);
        Task<List<EmployeeExamView>> GetSubmittedExams(int empId);

        //Question
        Task<IEnumerable<SubjectQuestion>> GetAllQuestions(int subjectId, string filter);
        Task<SubjectQuestionView> GetQuestion(int id);
        Task<IEnumerable<string>> GetQuestionType();
        Task<Response> AddQuestion(SubjectQuestionView sq);
        Task<HttpResponseMessage> UpdateQuestion(SubjectQuestionView sq);
        Task<Response> DeleteQuestion(int id);
        Task<Response> DeleteImage(int id, string image, int type, string updatedBy);

        /* Questionaire */
        Task<QuestionQueueView> GetApplicantExam(int ApplicantExamId, int currentPage, bool isNext, bool isSkip);
        Task<ExamStatistics> GetExamStatistic(int ApplicantExamId);
        Task<HttpResponseMessage> SaveAns(ApplicantExamAnswer response);
        Task<ApplicantExamStatistics> GetApplicantStat(int _examId);
        Task<HttpResponseMessage> BeginExam(SelectedApplicantExamView applicantExam);

        //Result
        Task<List<ApplicantResultListView>> GetApplicantExamResultList(int positionId);
        Task<ApplicantResultAnswersListView> GetApplicantAnswers(int applicantExamId);
        Task<List<HRMSv4.Shared.OnBoarding.Position>> GetExamPosition();

        Task<HttpResponseMessage> UpdateApplicantExam(SelectedApplicantExamView selectedApplicantExamView);
        Task<Response> PutEssayScore(ApplicantAnswers ans);

        Task<ExamResults> ShowResults(int ApplicantExamId, string userId);
    }
}

