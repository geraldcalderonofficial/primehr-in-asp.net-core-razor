using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Payroll;
using System.Net.Http.Json;
using Newtonsoft.Json;
using DevExpress.DataAccess.Native.Web;

namespace HRMSv4.Client.Service
{
    public class AllowanceTypeService : IAllowancetype
    {
        readonly HttpClient _httpClient;
        public AllowanceTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response> AddAllowanceType(AllowanceType allowanceType)
        {
            try
            {
                Response isResponse = new Response();

                var result = await _httpClient.PostAsJsonAsync("AllowanceType/AllowanceTypeAdd", allowanceType);
            
                if (result.IsSuccessStatusCode)
                {
                    isResponse = new Response
                    {
                        StatusCode = 200,
                        Value = "A new record was successfully added."
                    };
                }
                else
                {
                    isResponse = new Response
                    {
                        StatusCode = 404,
                        Value = "Please complete all information!"
                    };
                }

                return isResponse;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<AllowanceType> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AllowanceType>($"AllowanceType?id=" + id);
            return result;
        }

        public async Task<IEnumerable<AllowanceType>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<AllowanceType>>("AllowanceType/AllType");
            return result;
        }

        public async Task<List<AllowanceType>> GetAllowanceType(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AllowanceType>>("AllowanceType/AllowanceList?id=" + id);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<AllowanceType>> GetAllowFilter(int? id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AllowanceType>>($"AllowanceType/AllType?id={id}");
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<Response> GetUserData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> RemoveAllowanceType(int id)
        {
            try
            {
                Response res = new Response();
                var result = await _httpClient.DeleteAsync("AllowanceType/RemoveAllowanceType?id=" + id);
                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Record Deleted"
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong"
                    };
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<Response> UpdateAllowanceType(AllowanceType allowanceType)
        {
            throw new NotImplementedException();
        }
    }
}
