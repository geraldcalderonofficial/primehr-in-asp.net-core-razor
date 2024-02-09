using HRMSv4.Shared;

namespace HRMSv4.Client.Interface
{
    public interface IEthnicity
    {
        Task<IEnumerable<HRMSv4.Shared.Masterdata.Ethnicity>> GetAll();
        Task<HRMSv4.Shared.Masterdata.Ethnicity> Get(int id);
        Task<Response> Add(HRMSv4.Shared.Masterdata.Ethnicity eth);
        Task<Response> Update(HRMSv4.Shared.Masterdata.Ethnicity eth);
        Task<Response> Delete(int id);
        Task<Response> GetCheckDuplicate(HRMSv4.Shared.Masterdata.Ethnicity eth);
    }
}
