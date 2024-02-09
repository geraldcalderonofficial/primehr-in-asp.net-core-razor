using HRMSv4.Shared;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPlacement
    {
        Task<IEnumerable<PamNewEmployeeListView>> GetNewEmployees(string status);
        Task<PersonnelActionMemo> GetById(int id);
        Task<Response> ApproveNewEmployee(NewEmployeeApproveV2 newEmployee);
        Task<Response> DisapproveNewEmployee(int id); //for applicants kasi iba yung inauupdate na status
        Task<Response> Disapprove(int id, string userId); //for other
        Task<Response> DisapproveAll(List<int> memos, string userId);
        Task<IEnumerable<PamTransferEmployeeListView>> GetTransferEmployeesAll(string status);
        Task<IEnumerable<PamPromotionEmployeeListView>> GetPromotionEmployeesAll(string status);
        Task<HttpResponseMessage> ApprovePromotion(PromotionApprovedV2 promotion);
        Task<IEnumerable<PamDemotionEmployeeListView>> GetDemotionEmployeesAll(string status);
        Task<IEnumerable<RenewalEmployeeListView>> GetRenewalEmployeesAll(string status);
        Task<IEnumerable<EmpSeparationList>> GetSeparationEmployees(string sepStatus);
        Task<Response> ApproveAll(PersonnelActionMemoDates memos); //for other
        Task<IEnumerable<ReemploymentListView>> GetReemployment(string status);
        Task<HttpResponseMessage> StatusRequested(EmpSeparationList sep);
        Task<HttpResponseMessage> ApproveReemployment(ReemploymentApproved memo);
        Task<IEnumerable<ReElectionListView>> GetReelectionEmployeesAll(string status);
        Task<HttpResponseMessage> ApproveReelection(ReElectionApproved reelection);
        Task<IEnumerable<ReappointmentEmployeeListView>> GetReappointedEmployeesAll (string status);
        Task<HttpResponseMessage> ApproveReappointment(ReappointmentApproved reappoint);
        Task<IEnumerable<PamSalaryAdjustmentListView>> GetSalaryAdjustmentEmployeesAll(string status);
        Task<HttpResponseMessage> ApproveSalaryAdjustment(SalaryAdjustmentApprovedV2 sal);
        Task<List<PamStepIncrementListView>> GetStepIncrement(string status);
        Task<Response> PostApproveStepIncrement(StepIncrementListModel model);
    }
}
