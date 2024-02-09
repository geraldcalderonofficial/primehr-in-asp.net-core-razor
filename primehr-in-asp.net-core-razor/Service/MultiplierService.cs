using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrPolicy;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{

    public class MultiplierService : IMultiplier
    {

        private readonly HttpClient _httpClient;

        public MultiplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IQueryable<MultiplierView>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MultiplierView>>($"Multiplier/All");

            var queryableList = result.AsQueryable();
            return queryableList;
        }

        public async Task<Response> Insert(MultiplierView item)
        {
            try
            {

                var result = await _httpClient.PostAsJsonAsync($"Multiplier/Insert", item);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Response> Update(MultiplierView item)
        {
            try
            {

                var result = await _httpClient.PutAsJsonAsync($"Multiplier/Update", item);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                Response res = new Response();
                var result = await _httpClient.DeleteAsync("Multiplier/Delete?id=" + id);
                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Record Deleted."
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong."
                    };
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
