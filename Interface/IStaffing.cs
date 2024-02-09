using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IStaffing
    {
        Task<List<StaffingPlanSignatoryView>> GetAllStaffList();
        Task<IEnumerable<StaffingPlanView>> GetStaffingList(string orgId,int staffId);
        Task<Response> GenerateStaff(StaffingPlanView positionItem);
        Task<Response> Add(StaffingPlanView positionItem);
        Task<Response> AddStaffPlan(StaffingPlanSignatoryView item);
        Task<Response> Update(StaffingPlanView positionItem);
        Task<Response> Delete(int id);
        Task<StaffingPlan> GetStaffPlan(int planId);
        Task<Response> StaffPlanUpdate(StaffingPlanSignatoryView signatory);
    }
}
