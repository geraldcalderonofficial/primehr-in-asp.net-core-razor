using HRMSv4.Shared;

namespace HRMSv4.Client.Interface
{
    public interface ICountry
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<Country> GetACountry(int countryId);
    }
}
