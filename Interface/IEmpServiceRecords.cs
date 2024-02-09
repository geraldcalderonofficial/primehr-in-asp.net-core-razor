using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IEmpServiceRecords : IGenericRepository<ServiceRecord>
    {
        Task<IEnumerable<ServiceRecordListView>> GetServiceRecords(int employeeId);
    }
}
