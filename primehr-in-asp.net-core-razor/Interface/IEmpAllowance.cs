using HRMSv4.Shared.Payroll;

namespace HRMSv4.Client.Interface
{
    public interface IEmpAllowance
    {
        Task<List<EmployeeAllowanceView>> GetAllowances(int employeeId);
    }
}
