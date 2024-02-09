using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IJpHome
    {
        Task<List<JobCategoryDashboardListView>> GetCategory();
    }
}
