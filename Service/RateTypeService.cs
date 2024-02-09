using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class RateTypeService : IRateType
    {
        private readonly HttpClient _httpClient;

        public RateTypeService(HttpClient httpClient) 
        {
         _httpClient = httpClient;
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"RateType/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //throw new NotImplementedException();
        }

        public async Task<Response> Add(RateType rate)
        {
            //rate.JobVacancy = new JobVacancy();
            var result = await _httpClient.PostAsJsonAsync("RateType", rate);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<RateType>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<RateType>>("RateType");
            return result;
            //throw new NotImplementedException();
        }

        public async Task<Response> Update(RateType rate)
        {
            var result = await _httpClient.PutAsJsonAsync<RateType>($"RateType", rate);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<RateType>> Get(bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<RateType>>($"RateType/List/{isPlantilla}");
            return result;
        }

        public async Task<RateType> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<RateType>($"RateType/GetById/{id}");
            return result;
        }

        public async Task<Response> SalaryRate(int id, decimal salary)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>($"RateType/SalaryRate/{id}/{salary.ToString()}");
            return result;
        }

        public async Task<Response> GetCheckDuplicate(RateType rate)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"RateType/CheckDuplicate", rate);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //public async Task<RateType> Get(bool isPlantilla)
        //{
        //    var result = await _httpClient.GetFromJsonAsync<RateType>($"/api/RateType/List/{isPlantilla}");
        //    return result;
        //}
    }
}
