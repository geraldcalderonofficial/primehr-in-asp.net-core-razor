using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmployeeCredentials : ICredentials
    {
        private readonly HttpClient _httpClient;
        public ISEmployeeCredentials(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Approved(EmployeeCredentialUpdate data)
        {
            var result = await _httpClient.PostAsJsonAsync($"Credentials", data);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Credentials/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<EmployeeCredential>> GetAll(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeCredential>>($"Credentials/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<EmployeeCredential> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeCredentialView>> GetByView(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeCredentialView>>($"Credentials/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<SelectListItems>> GetFileType(string role)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"Credentials/GetFileTypes/{role}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Insert(EmployeeCredential entity)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> Update(EmployeeCredential entity)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> UploadFile(List<UploadedFile> _uploadedFile)
        {
            var result = await _httpClient.PostAsJsonAsync("Credentials/", _uploadedFile);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();

            //var result = await _httpClient.PostAsJsonAsync<List<UploadedFile>>("/api/Credentials", _uploadedFile);
            //return result;
        }
    }
}
