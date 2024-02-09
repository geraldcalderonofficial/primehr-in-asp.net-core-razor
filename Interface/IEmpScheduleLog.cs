using HRMSv4.Shared.Timekeeping;

namespace HRMSv4.Client.Interface
{
    public interface IEmpScheduleLog
    {
        Task<List<EmployeeScheduleLog>> GetAll(int employeeId, DateTime date);
    }
}
