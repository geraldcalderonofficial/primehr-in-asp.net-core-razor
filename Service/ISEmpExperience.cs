using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISEmpExperience : IEmpExperience
    {
        private readonly HttpClient _httpClient;
        public ISEmpExperience(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(EmploymentExperience entity)
        {
            Response res = new Response();
            try
            {
                var result = await _httpClient.PostAsJsonAsync("EmployeeExperience", entity);

                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        res = new Response
                        {
                            StatusCode = 200,
                            Value = "A new record was successfully added."
                        };
                        return res;
                    case System.Net.HttpStatusCode.NotFound:
                        res = new Response
                        {
                            StatusCode = 400,
                            Value = "A existing record already exists!"
                        };
                        return res;
                    default:
                        res = new Response
                        {
                            StatusCode = 500,
                            Value = "Something went wrong unable to a new record."
                        };
                        return res;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"EmployeeExperience/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<EmploymentExperience> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmploymentExperience>($"EmployeeExperience/Find/{id}");
            return result;
        }

        public async Task<IEnumerable<EmpExperienceView>> GetAll(int employeeId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmpExperienceView>>("EmployeeExperience/All?id=" + employeeId);
            return result;
        }

        public async Task<RateType> GetFindRate(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<RateType>("EmployeeExperience/FindRate?id=" + id);
            return result;
        }

        public async Task<List<SelectListItems>> RateType(string selected)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"EmployeeExperience/RateType/{selected}");
            return result;
        }

        public async Task<List<SelectListItems>> GetIndustry()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>("EmployeeExperience/GetIndustry");
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EmploymentStatus> GetFindStatus(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmploymentStatus>("EmployeeExperience/FindStatus?id=" + id);
            return result;
        }

        public async Task<List<SelectListItems>> Status()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>($"EmployeeExperience/Status");
            return result;
        }

        public async Task<Response> Update(EmploymentExperience entity)
        {
            Response res = new Response();
            try
            {
                var result = await _httpClient.PutAsJsonAsync("EmployeeExperience/Update", entity);

                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        res = new Response
                        {
                            StatusCode = 200,
                            Value = "A record was successfully updated."
                        };
                        return res;
                    case System.Net.HttpStatusCode.NotFound:
                        res = new Response
                        {
                            StatusCode = 400,
                            Value = "No record found!"
                        };
                        return res;
                    default:
                        res = new Response
                        {
                            StatusCode = 500,
                            Value = "Something went wrong unable to a new record."
                        };
                        return res;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
