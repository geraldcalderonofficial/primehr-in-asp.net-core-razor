using DevExpress.Charts.Native;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace HRMSv4.Client.Service
{
    public class ISTravelOrder : ITravelOrder
    {
        private readonly HttpClient _httpClient;
        public ISTravelOrder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response> Delete(int id)
        {
            try
            {
                var result = await _httpClient.DeleteAsync("TravelOrder/Delete?id=" + id);
                Response res = new Response();
                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "A new records sucessfully added."
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong!."
                    };
                }
                return (res);
            }
            catch (Exception e)
            {
                return new Response { StatusCode = 400, Value = e.Message };
            }
        }
        public async Task<Response> Add(TravelOrderList item)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"TravelOrder", item);
                var msg = result.Content.ReadAsStringAsync();

                Response res = new();
                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "A new records sucessfully added."
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = msg.Result
                    };
                }
                return (res);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<TravelOrder>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TravelOrder>>("TravelOrder/All");
            return result;
        }

        public async Task<List<TravelOrderEmployee>> GetAllEmpById(int id, bool isEmployee)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<TravelOrderEmployee>>("TravelOrder/AllEmpById/?id=" + id + "&isEmployee=" + isEmployee);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
