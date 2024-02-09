using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPersonalActionMemo : IGenericRepository<PersonnelActionMemo>
    {
        Task<List<SelectListItems>> GetEmploymentStatus();
        Task<Response> GetRenewal(PersonnelActionMemo memo);
        Task<Response> GetReElection(PersonnelActionMemo memo);
        Task<Response> AddEmployeeSeparation(PersonnelActionMemo memo);
        Task<Response> GetSeparationType(int pamId);
        Task<Response> GetPersonnelStatus(int id);
        Task<IEnumerable<SalAdjDatesAnnex>> GetSalAdjDateEffectivity();
        Task<GetSalaryRateListView> GetSalaryRate(int sgId, string salaryGradeNumber, int serviceRecordId);
        Task<IEnumerable<PamTurnAroundTimeView>> GetApplicants(int posId);
        Task<Response> Put(PersonnelActionMemo memo);
        Task<Response> New(PersonnelActionMemo entity);
    }
}
