using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPositionCompetency
    {

        Task<IEnumerable<PositionCompetencyViewModel>> Get(int id);
        Task<HttpResponseMessage> Add(PositionCompetency pc);
        Task<HttpResponseMessage> Update(PositionCompetency pc);
        Task<HttpResponseMessage> Delete(int id);
    }
}
