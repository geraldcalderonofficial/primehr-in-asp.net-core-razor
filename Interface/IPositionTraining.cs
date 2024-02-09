using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IPositionTraining
    {
        Task<IEnumerable<PositionTrainingViewModel>> GetAll();
        Task<IEnumerable<PositionTrainingViewModel>> Get(int id);
        Task<List<PositionTrainingViewModel>> Add(PositionTrainingViewModel positionTraining);
        Task<Response> Update(PositionTrainingViewModel positionTraining);
        Task<HRMSv4.Shared.Response> Delete(int id);

    }
}
