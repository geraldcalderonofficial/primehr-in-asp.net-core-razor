using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CountryService : ICountry
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Country> GetACountry(int countryId)
        {
            var result = await _httpClient.GetFromJsonAsync<Country>("Country/GetACountry/?countryId" + countryId);
            return result;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Country>>($"Country/GetAllCountries");
            return result;
        }
    }
}
