using HRMSv4.Shared;
using HRMSv4.Shared.Report;

namespace HRMSv4.Client.Interface
{
    public interface IReportSignatory
    {
        Task<List<ReportSignatoryView>> GetReportSignatories(string reportName, string purpose);
        Task<ReportSignatoryView> GetReportSignatory(string reportName, string purpose, string signatoryName);
        Task<Response> AddReportSignatory(ReportSignatoryView signatory);
        Task<Response> UpdateReportSignatory(ReportSignatoryView signatory);
        Task<Response> DeleteReportSignatory(int id);
    }
}
