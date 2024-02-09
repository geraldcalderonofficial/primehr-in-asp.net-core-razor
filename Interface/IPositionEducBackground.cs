using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPositionEducBackground
    {
        Task<IEnumerable<PositionEducationalBackgroundViewModel>> GetAll(int id);
        Task<PositionEducationalBackground> Get(int id);
        Task<HttpResponseMessage> Add(PositionEducationalBackground peb);
        Task<HttpResponseMessage> Update(PositionEducationalBackground peb);
        Task<HttpResponseMessage> Delete(int id);
    }
}
