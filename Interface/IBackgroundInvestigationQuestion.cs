using HRMSv4.Shared;
using HRMSv4.Shared.Exam;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IBackgroundInvestigationQuestion
    {
        Task<IEnumerable<BackgroundInvestigationQuestion>> GetAll();
        Task<BackgroundInvestigationQuestion> Get(int id);
        Task<Response> Add(BackgroundInvestigationQuestion bgq);
        Task<Response> Update(BackgroundInvestigationQuestion bgq);
        Task<Response> Delete(int id);
        Task<IEnumerable<Position>> GetOpenPositions();
        Task<IEnumerable<ApplicantListView>> GetApplicants(int positionId);
        Task<Response> PostBgInvestigation(InvestigationListView bi);
        Task<BgQuestionView> GetQuestionItems(int id, int currentPage, bool isNext);
        Task<HttpResponseMessage> SaveAnswer(BackgroundInvestigationItem response);
        Task<List<BgItemsListView>> GetBgItems(int id);
        Task<HttpResponseMessage> PostItems(List<BgItemsListView> bgItems);
        Task<List<InvestigationListView>> GetInvestigations();
        Task<ReportBg> PostReports(ReportBg rbg); 
    }
}
