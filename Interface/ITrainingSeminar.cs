using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ITrainingSeminar
    {
        Task<IEnumerable<TrainingSeminarListview>> GetAll(int id);
        Task<TrainingSeminar> Get(int id);
        Task<HttpResponseMessage> Add(TrainingSeminar ts);
        Task<HttpResponseMessage> Update(TrainingSeminar ts);
        Task<HttpResponseMessage> Delete(int id);
    }
}
