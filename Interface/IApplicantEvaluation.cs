using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;

namespace HRMSv4.Client.Interface
{
    public interface IApplicantEvaluation
    {
        //type
        Task<IEnumerable<QuestionType>> GetTypes();
        Task<QuestionType> GetType(int id);
        Task<Response> AddType(QuestionType category);
        Task<Response> Update(QuestionType category);
        Task<Response> Delete(int id);
        Task<IEnumerable<CrQuestionListView>> GetAllQuestion(int typeId);

        //question
        Task<Response> AddQuestion(CrQuestionModel crq);
        Task<CrQuestionModel> GetQuestion(int id);
        Task<Response> DeleteQuestion(int id);

        //dashboard
        Task<ApplicantEvaluationCount> GetCrDashboardCount();
        Task<IEnumerable<ApplicationEvaluationListView>> GetEvaluations();

        //evaluation
        Task<ApplicationEvaluationListView> PostStartEvaluation(int empId, int charReferenceId);
        Task<ApplicantEvaluationView> GetCrQuestions(int crqId, int currentPage, bool isNext, int empId, int characterRefId);
        Task<HttpResponseMessage> SaveAnswer(CharacterReferenceQuestionnaireAnswer response);
    }
}
