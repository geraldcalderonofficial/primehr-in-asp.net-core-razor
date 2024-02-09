using HRMSv4.Shared;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICredentials : IGenericRepository<EmployeeCredential>
    {
        Task<HttpResponseMessage> UploadFile(List<UploadedFile> _uploadedFile);
        Task<HttpResponseMessage> Delete(int id);
        Task<HttpResponseMessage> Approved(EmployeeCredentialUpdate data);
        Task<List<SelectListItems>> GetFileType(string role);
        Task<IEnumerable<EmployeeCredentialView>> GetByView(int id);

    }
}
