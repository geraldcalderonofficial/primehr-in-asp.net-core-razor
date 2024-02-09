using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CompanyProfileService : ICompanyProfile
    {
        private readonly HttpClient _httpClient;

        public CompanyProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SystemParameterViewModel> Get(string userId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<SystemParameterViewModel>("CompanyProfile?userId=" + userId);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<Response> Update(SystemParameterViewModel sysParam)
        {
            try
            {
                sysParam.CompanyLogo = "";
                sysParam.LogoSecondary = "";
                var result = await _httpClient.PutAsJsonAsync<SystemParameterViewModel>($"CompanyProfile", sysParam);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<string> UploadAvatar(List<UploadedFile> _uploadedFile)
        {
            var postResult = await _httpClient.PostAsJsonAsync("CompanyProfile/Avatar", _uploadedFile);

            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var imgUrl = Path.Combine(AppInfo.ApiUrl, postContent);
                return imgUrl;
            }
        }

        public async Task<string> UploadAvatarV2(int isAvatar, List<UploadedFile> uploadedFile)
        {
            var postResult = await _httpClient.PostAsJsonAsync("CompanyProfile/v2-avatar?isAvatar=" + isAvatar, uploadedFile);

            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var imgUrl = Path.Combine(AppInfo.ApiUrl, postContent);
                return imgUrl;
            }
        }
    }
}
