using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpCommunityService : IEmpComService
    {
        private readonly HttpClient _httpClient;
        public ISEmpCommunityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"CommunityService/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<EmployeeCommunityService>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeCommunityService>>("CommunityService/All?id=" + id);
            return result;
        }

        public async Task<EmployeeCommunityService> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeCommunityService>($"CommunityService/{id}");
            return result;
        }

        public async Task<Response> Add(EmployeeCommunityService entity)
        {
            //Response res = new Response();

            var result = await _httpClient.PostAsJsonAsync($"CommunityService/Add", entity);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //switch (result.StatusCode)
            //{
            //    case System.Net.HttpStatusCode.OK:
            //        res = new Response
            //        {
            //            StatusCode = 200,
            //            Value = "A new record was successfully added."
            //        };
            //        return res;
            //    case System.Net.HttpStatusCode.NotFound:
            //        res = new Response
            //        {
            //            StatusCode = 400,
            //            Value = "A existing record already exists!"
            //        };
            //        return res;
            //    default:
            //        res = new Response
            //        {
            //            StatusCode = 500,
            //            Value = "Something went wrong unable to a new record."
            //        };
            //        return res;
            //}
        }

        public async Task<Response> Put(EmployeeCommunityService entity)
        {
            //Response res = new Response();

            var result = await _httpClient.PostAsJsonAsync($"CommunityService/Update", entity);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //switch (result.StatusCode)
            //{
            //    case System.Net.HttpStatusCode.OK:
            //        res = new Response
            //        {
            //            StatusCode = 200,
            //            Value = "A record was successfully updated."
            //        };
            //        return res;
            //    case System.Net.HttpStatusCode.NotFound:
            //        res = new Response
            //        {
            //            StatusCode = 400,
            //            Value = "No record exists!"
            //        };
            //        return res;
            //    default:
            //        res = new Response
            //        {
            //            StatusCode = 500,
            //            Value = "Something went wrong unable to a new record."
            //        };
            //        return res;
            //}

            //var result = await _httpClient.PutAsJsonAsync<EmployeeCommunityService>("/api/CommunityService/", entity);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();
        }

        async Task<IEnumerable<EmployeeCommunityListView>> IEmpComService.GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmployeeCommunityListView>>("CommunityService/All?id=" + id);
            return result;
        }

        Task<HttpResponseMessage> IGenericRepository<EmployeeCommunityService>.Insert(EmployeeCommunityService entity)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Update(EmployeeCommunityService entity)
        {
            throw new NotImplementedException();
        }
    }
}
