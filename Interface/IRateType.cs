using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IRateType
    {
        Task<IEnumerable<RateType>> GetAll();
        Task<RateType> GetById(int id);
        Task<IEnumerable<RateType>> Get(bool isPlantilla);
        Task<Response> Add(RateType rate);
        Task<Response> Update(RateType rate);
        Task<Response> Delete(int id);
        Task<Response> SalaryRate(int id, decimal salary);
        Task<Response> GetCheckDuplicate(RateType rate);
    }
}
