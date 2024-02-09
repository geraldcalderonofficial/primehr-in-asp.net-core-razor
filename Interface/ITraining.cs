using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ITraining
    {
        Task<IEnumerable<Training>> GetAll();
        Task<IEnumerable<Training>> GetType(string selected);
        Task<IEnumerable<Training>> GetCategory(string type, string category);
        Task<Training> Get(int id);
        Task<Response> Add(Training training);
        Task<Response> Update(Training training);
        Task<Response> Delete(int id);
        Task<IEnumerable<Training>> ListOfTraining();
        Task<Response> GetCheckDuplicate(Training training);
        Task<List<string>> GetTrainingType();
        Task<List<string>> GetCategories();
    }
}
