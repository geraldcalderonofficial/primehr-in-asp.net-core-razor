using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static HRMSv4.Shared.OnBoarding.EducationalAttainment;

namespace HRMSv4.Client.Service
{
    public class ISEduAttainment : IEduAttainment
    {
        private readonly HttpClient _httpClient;
        public ISEduAttainment(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(EducationalAttainment entity)
        {
            try
            {
                var res = new Response();
                var result = await _httpClient.PostAsJsonAsync($"EducationalAttainment", entity);
                if (!result.IsSuccessStatusCode)
                {
                    res.StatusCode = 400;
                    res.Value = "Something went wrong!";
                    return res;
                } else
                {
                    res.StatusCode = 200;
                    return res;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Response> Delete(int id)
        {
            var res = new Response();
            var result = await _httpClient.DeleteAsync($"EducationalAttainment/{id}");
            if (!result.IsSuccessStatusCode)
            {
                res.StatusCode = 400;
                res.Value = "Something went wrong!";
                return res;
            }
            else
            {
                res.StatusCode = 200;
                return res;
            }
        }

        public async Task<EducationalAttainment> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EducationalAttainment>($"EducationalAttainment/{id}");
            return result;
        }

        public async Task<IEnumerable<EducationalListview>> GetAll(int employeeId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EducationalListview>>("EducationalAttainment/All?id="+employeeId);
            return result;
        }

        public async Task<List<SelectListItems>> GetDegree(string level)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>("EducationalAttainment/Degree?level=" + level);
            return result;
        }

        public async Task<IEnumerable<EducationalAttainment>> LoadEducAttainment(int employeeId)
        {
            var result =  await _httpClient.GetFromJsonAsync<IEnumerable<EducationalAttainment>>($"EducationalAttainment/EducAttainment/{employeeId}");
            return result;
        }

       public async Task<Response> Update(EducationalAttainment entity)
        {
            var res = new Response();
            var result = await _httpClient.PutAsJsonAsync("EducationalAttainment/", entity);
            if (!result.IsSuccessStatusCode)
            {
                res.StatusCode = 400;
                res.Value = "Something went wrong!";
                return res;
            }
            else
            {
                res.StatusCode = 200;
                return res;
            }
        }
    }
}
