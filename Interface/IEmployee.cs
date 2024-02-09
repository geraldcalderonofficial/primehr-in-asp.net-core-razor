using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.Timekeeping;
using HRMSv4.Shared.Payroll;

namespace HRMSv4.Client.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<EmployeeListView>> GetEmployeeAsync();
        Task<List<EmployeeListView>> GetAll();
        Task<IEnumerable<EmployeeListView>> GetListEmployee(int employeeSearch, string? empDept, int empOrderBy);
        Task<IQueryable<EmployeeListView>> GetQueryEmployee(int empSearch, string? empDept, int empOrderBy);
        Task<Employee> Get(long id);
        Task<EmployeeListView> View(long id);
        Task<Response> Add(Employee entity);
        Task<Response> Update(Employee entity);
        Task<HttpResponseMessage> InviteEmployee(EmployeeInvitationView emp);
        Task<Response> Delete(int id);
        Task<ServiceRecordDetailView> Details (int id);
        Task<IEnumerable<EmployeeRelative>> EmployeeRelatives(int employeeId);
        Task<string> UploadAvatarImage(MultipartFormDataContent content);
        Task<string> UploadAvatar(List<UploadedFile> _uploadedFile);
        Task<EmployeeStatus> Status(int id);
        Task<ServiceRecord> LastServiceRecord(int id);
        Task<List<Nationality>> Nationalities();
        Task<int> EmpSrCount(int id);
        Task<EmpSeparationDetail> FindEmpDetails(int id);
        Task<ProfileView> GetProfileView(int id);
        Task<IEnumerable<EmployeeListForPremium>> GetEmployeeListForPremium();
        Task<List<ClusterMemberDetails>> GetRangeofEmployeeByHighestLevel(int firstId, int secondId, string status);
        Task<bool> CheckExistingEmployeeNumber(string employeeNumber);
        Task<List<EmployeeListView>> GetAllFiltered(int isPlantilla);
    }
}
