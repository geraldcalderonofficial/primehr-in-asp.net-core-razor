using HRMSv4.Shared.Payroll;
using HRMSv4.Shared.Timekeeping;

namespace HRMSv4.Client.Interface
{
    public interface IEmpLoan
    {
        Task<List<EmployeeLoanView>> GetAll(int employeeId);
    }
}
