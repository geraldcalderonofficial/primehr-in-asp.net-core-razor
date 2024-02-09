using HRMSv4.Shared.Payroll;

namespace HRMSv4.Client.Interface
{
    public interface IEmpPremium
    {
        Task<List<EmployeePremiumView>> GetPremiums(int employeeId);
    }
}
