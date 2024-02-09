using HRMSv4.Shared;

namespace HRMSv4.Client.Interface
{
    public interface IAuditTrail
    {
        Task<List<AuditLogView>> GetAll();
        Task<List<AuditLogView>> GetByDate(DateTime fromDate, DateTime toDate);
    }
}
