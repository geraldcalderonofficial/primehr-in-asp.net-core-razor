using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace HRMSv4.Client.Service
{

    public class AddressService : IAddress
    {
        private readonly HttpClient _httpClient;
        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region v1
        public async Task<LocationListView> GetLocation(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<LocationListView>($"Address/Location/{psgc}");
            return result;
        }

        public async Task<PsgcForEditList> GetPsgcForEdit(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<PsgcForEditList>($"Address/PsgcForEdit/{psgc}");
            return result;
        }

        public async Task<List<SelectListItems>> ListofBarangays(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/Barangays/{psgc}");
            return result;
        }

        public async Task<List<SelectListItems>> ListofCountries()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/Countries");
            return result;
        }

        public async Task<List<SelectListItems>> ListofMunicipalities(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/Municipalities/{psgc}");
            return result;
        }

        public async Task<List<SelectListItems>> ListofProvinces(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"/api/Address/Provinces/{psgc}");
            return result;
        }

        public async Task<List<SelectListItems>> ListofRegions()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"/api/Address/Regions");
            return result;
        }

        async Task<string> IAddress.GetBarangay(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<string>($"/api/Address/Barangay/{psgc}");
            return result;
        }

        async Task<string> IAddress.GetMunicipality(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<string>($"/api/Address/Municipality/{psgc}");
            return result;
        }

        async Task<string> IAddress.GetProvince(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<string>($"/api/Address/Province/{psgc}");
            return result;
        }

        async Task<string> IAddress.GetRegion(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<string>($"/api/Address/Region/{psgc}");
            return result;
        }
        #endregion

        #region v2
        public async Task<List<SelectListItem>> RegionList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItem>>("Address/v2/Regions");
            return result;
        }

        public async Task<List<SelectListItem>> ProvinceList(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItem>>($"Address/v2/Provinces/{psgc}");
            return result;
        }
        public async Task<List<SelectListItem>> CityList(string psgc)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<SelectListItem>>($"Address/v2/Municipalities/{psgc}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<List<SelectListItem>> BarangayList(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItem>>($"Address/v2/Barangays/{psgc}");
            return result;
        }

        #endregion

        #region v3
        public async Task<List<SelectListItems>> RegionPsgc()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/v3/RegionPsgc/");
            return result;
        }

        public async Task<List<SelectListItems>> ProvincePsgc(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/v3/ProvincePsgc?psgc=" + psgc);
            return result;
        }

        public async Task<List<SelectListItems>> CityPsgc(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/v3/CityPsgc?psgc=" + psgc);
            return result;
        }

        public async Task<List<SelectListItems>> NcrPsgc(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/v3/NcrPsgc?psgc=" + psgc);
            return result;
        }
        public async Task<List<SelectListItems>> NcrPsgcV2(string psgc, bool isProv)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/v3/NcrPsgcV2?psgc=" + psgc + "&isProv=" + isProv);
            return result;
        }

        public async Task<List<SelectListItems>> BarangayPsgc(string psgc)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Address/v3/BarangayPsgc?psgc=" + psgc);
            return result;
        }
        #endregion
    }
}
