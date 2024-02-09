using HRMSv4.Shared;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICompanyProfile
    {
        Task<SystemParameterViewModel> Get(string userId);
        Task<Response> Update(SystemParameterViewModel sysParam);
        Task<string> UploadAvatar(List<UploadedFile> _uploadedFile);
        Task<string> UploadAvatarV2(int isAvatar, List<UploadedFile> uploadedFile);
    }
}
