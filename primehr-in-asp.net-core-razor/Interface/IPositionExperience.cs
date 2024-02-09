using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPositionExperience
    {
        Task<IEnumerable<PositionExperienceViewModel>> GetAll(int id);
        Task<HttpResponseMessage> Add(PositionExperience pex);
        Task<HttpResponseMessage> Update(PositionExperience pex);
        Task<HttpResponseMessage> Delete(int id);
    }
}
