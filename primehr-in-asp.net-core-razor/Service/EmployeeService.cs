using System.Net.Http.Json;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.DbViews;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components;
using HRMSv4.Shared.Payroll;

namespace HRMSv4.Client.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly IHttpContextAccessor _context;
        private readonly NavigationManager _nav;
        public EmployeeService(HttpClient httpClient, ILocalStorageService localStorage, IHttpContextAccessor context, NavigationManager navigationManager) 
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _context = context;
            _nav = navigationManager;
        }

        public async Task<Response> Add(Employee entity)
        {
            var result = await _httpClient.PostAsJsonAsync<Employee>($"Employee", entity);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Employee/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Employee> Get(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"Employee/{id}");
            return result;
        }

        public async Task<List<EmployeeListView>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeListView>>("Employee");
            return result;
        }

        public async Task<IEnumerable<EmployeeRelative>> EmployeeRelatives(int employeeId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeRelative>>($"Employee/FamilyRelatives/{employeeId}");
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }         
        }

        public async Task<Response> Update(Employee entity)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<Employee>("Employee/", entity);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeListView>> GetListEmployee(int empSearch, string? empDept, int empOrderBy)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeListView>>($"Employee/List?empSearch={empSearch}&empDept={empDept}&empOrderBy={empOrderBy}");
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> UploadAvatarImage(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("Employee/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine(AppInfo.ApiUrl, postContent);
                return imgUrl;
            }
        }

        public async Task<string>  UploadAvatar(List<UploadedFile> _uploadedFile)
        {
            var postResult = await _httpClient.PostAsJsonAsync("Employee/Avatar", _uploadedFile);

            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                //var imgUrl = Path.Combine(AppInfo.ApiUrl, postContent);
                return postContent;
            }
        }

        public async Task<HttpResponseMessage> InviteEmployee(EmployeeInvitationView emp)
        {
            var result = await _httpClient.PostAsJsonAsync($"Employee/InviteEmployee", emp);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<ServiceRecordDetailView> Details(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceRecordDetailView>($"Employee/Details/{id}");
            return result;
        }

        public async Task<EmployeeStatus> Status(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeStatus>($"Employee/GetStatus/{id}");
            return result;
        }

        public async Task<ServiceRecord> LastServiceRecord(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceRecord>($"Employee/LastServiceRecord/{id}");
            return result;
        }

        public async Task<int> EmpSrCount(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"Employee/EmployeeCountServiceRecord/{id}");
            return result;
        }

        public async Task<List<Nationality>> Nationalities()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Nationality>>($"Employee/Nationality");
            return result;
        }

        public async Task<EmployeeListView> View(long id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<EmployeeListView>($"employee/view?id={id}");
                if (result != null)
                    return result;

                return null;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<EmpSeparationDetail> FindEmpDetails(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmpSeparationDetail>($"Employee/EmployeeInfo/{id}");
            return result;
        }

        public async Task<ProfileView> GetProfileView(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ProfileView>($"ProfileUpdate/GetView/{id}");
            return result;
        }

        public async Task<IQueryable<EmployeeListView>> GetQueryEmployee(int empSearch, string? empDept, int empOrderBy)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeListView>>($"Employee/List?empSearch={empSearch}&empDept={empDept}&empOrderBy={empOrderBy}");

                var queryList = result.AsQueryable();

                return queryList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async  Task<IEnumerable<EmployeeListForPremium>> GetEmployeeListForPremium()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeListForPremium>>("Employee/EmployeeListForPremium");
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /* For Timekeeping Employee listing */
        public async Task<IEnumerable<EmployeeListView>> GetEmployeeAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeListView>>("Employee");
            return result;
        }

        public async Task<List<ClusterMemberDetails>> GetRangeofEmployeeByHighestLevel(int firstId, int secondId, string status)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ClusterMemberDetails>>("Employee/GetRangeofEmployeeByHighestLevel?firstId=" + firstId + "&secondId=" + secondId + "&status=" + status);
            return result;
        }

        public async Task<bool> CheckExistingEmployeeNumber(string employeeNumber)
        {
            var result = await _httpClient.GetFromJsonAsync<bool>("Employee/CheckExistingEmployeeNumber?employeeNumber=" + employeeNumber);
            return result;
        }
        public async Task<List<EmployeeListView>> GetAllFiltered(int isPlantilla)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<EmployeeListView>>("Employee/GetAllFiltered?isPlantilla=" + isPlantilla);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}
