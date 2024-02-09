using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using System.Web.Mvc;

namespace HRMSv4.Client.Interface
{
    public interface IAddress
    {
        #region v1
        Task<List<SelectListItems>> ListofRegions();
        Task<List<SelectListItems>> ListofProvinces(string psgc);
        Task<List<SelectListItems>> ListofMunicipalities(string psgc);
        Task<List<SelectListItems>> ListofBarangays(string psgc);
        Task<List<SelectListItems>> ListofCountries();
        Task<string> GetRegion(string psgc);
        Task<string> GetMunicipality(string psgc);
        Task<string> GetProvince(string psgc);
        Task<string> GetBarangay(string psgc);
        Task<LocationListView> GetLocation(string psgc);
        Task<PsgcForEditList> GetPsgcForEdit(string psgc);
        #endregion

        #region v2
        Task<List<SelectListItem>> RegionList();
        Task<List<SelectListItem>> ProvinceList(string psgc);
        Task<List<SelectListItem>> CityList(string psgc);
        Task<List<SelectListItem>> BarangayList(string psgc);
        #endregion

        #region v3
        Task<List<SelectListItems>> RegionPsgc();
        Task<List<SelectListItems>> ProvincePsgc(string psgc);
        Task<List<SelectListItems>> CityPsgc(string psgc);
        Task<List<SelectListItems>> NcrPsgc(string psgc);
        Task<List<SelectListItems>> NcrPsgcV2(string psgc, bool isProv);
        Task<List<SelectListItems>> BarangayPsgc(string psgc);
        #endregion
    }
}
