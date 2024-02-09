using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmployeeMasterList
    {
        Task<IQueryable<HRMSv4.Shared.OnBoarding.EmployeeMasterListView>> All(EmployeeMasterListFilterView employee);
    }
}
