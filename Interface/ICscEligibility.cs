using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICscEligibility
    {
        Task<IEnumerable<CscEligibility>> GetAll();
        Task<List<CscEligibility>> Dropdown();
        Task<CscEligibility> Get(int id);
        Task<Response> Add(CscEligibility eligibility);
        Task<Response> Update(CscEligibility eligibility);
        Task<Response> Delete(int id);
        Task<List<SelectListItems>> ListofEligibility();
        Task<Response> GetCheckDuplicate(CscEligibility eligibility);
    }
}
