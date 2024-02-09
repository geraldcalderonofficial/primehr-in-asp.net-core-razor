using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IServiceRecord
    {
        Task<IEnumerable<ServiceRecordListView>> ListofServiceRecords(int empId);
        Task<ServiceRecord> LatestServiceRecords(int empId);
        Task<bool> StepIncrementQualification(int empId);
    }
}
