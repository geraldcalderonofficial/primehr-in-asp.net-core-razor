using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IProfileUpdate
    {
        Task<ProfileUpdateView> Get(int id);
        Task<Response> Add(ProfileUpdate request);
    }
}
