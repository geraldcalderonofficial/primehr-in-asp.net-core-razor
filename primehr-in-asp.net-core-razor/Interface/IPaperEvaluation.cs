using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;

namespace HRMSv4.Client.Interface
{
    public interface IPaperEvaluation
    {

        Task<PaperEvaluation> GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaperEvaluationTemplateItem>> GetTemplateItems();
        Task<PaperEvaluationTemplateItem> Get(int id);
        Task<HttpResponseMessage> Add(PaperEvaluationTemplateItem temp);
        Task<HttpResponseMessage> Update(PaperEvaluationTemplateItem temp);
        Task<HttpResponseMessage> Delete(int id);

        //applicants
        Task<IEnumerable<Position>> GetOpenPositions();
        Task<List<EvaluationApplicantListView>> GetApplicants(int positionId);
        Task<Response> PostApplicantEvaluation(PaperEvaluation pe);
        Task<EvaluationItemsListView> GetForEvaluation(int peId);
        Task<HttpResponseMessage> PutPaperEvaluationItem(PaperEvaluationItemListView item);

        //for reporting summary
        Task<IEnumerable<PaperEvaluationItemSummaryReport>> GetPaperEvaluationItems(DateTime date);
       
    }
}
