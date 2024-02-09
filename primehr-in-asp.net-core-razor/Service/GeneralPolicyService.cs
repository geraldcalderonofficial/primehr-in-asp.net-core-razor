using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using HRMSv4.Shared.HrPolicy;
using HRMSv4.Shared.Timekeeping;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class GeneralPolicyService : IGeneralPolicy
    {
        private readonly HttpClient _httpClient;
        public GeneralPolicyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<HttpResponseMessage> Add(GeneralPolicy gp)
        //{
        //    var result = await _httpClient.PostAsJsonAsync("/api/GeneralPolicy", gp);
        //    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        //    return result.EnsureSuccessStatusCode();
        //}

        public async Task<HttpResponseMessage> AddJobApplication(JobApplicationPolicy jap)
        {
            var result = await _httpClient.PostAsJsonAsync("GeneralPolicy/PostJobApplicationPolicy", jap);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<GeneralPolicy> Get()
        {
            var result = await _httpClient.GetFromJsonAsync<GeneralPolicy>("GeneralPolicy");
            return result;
        }

        public async Task<JobApplicationPolicy> GetJobApplicationView()
        {
            var result = await _httpClient.GetFromJsonAsync<JobApplicationPolicy>("GeneralPolicy/GetViewJobApplication");
            return result;
        }

        public async Task<GeneralPolicyListView> GetView()
        {
            var result = await _httpClient.GetFromJsonAsync<GeneralPolicyListView>("GeneralPolicy/GetView");
            return result;
        }

        public async Task<Response> Add(GeneralPolicy cr)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<GeneralPolicy>($"GeneralPolicy", cr);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<int>> GetEmployeeUpdateList(int isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<List<int>>("GeneralPolicy/EmployeeUpdateList?isPlantilla=" + isPlantilla);
            return result;
        }
        public async Task<Response> UpdateSalaryGrade(EmployeeIdListView emp)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<EmployeeIdListView>($"GeneralPolicy/UpdateSalaryGrade", emp);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TimeLogPolicy> GetTimeLogPolicy()
        {
            var result = await _httpClient.GetFromJsonAsync<TimeLogPolicy>("GeneralPolicy/GetTimeLogPolicy");
            return result;
        }

        public async Task<Response> PostTimeLogPolicy(TimeLogPolicy tl)
        {
            var result = await _httpClient.PostAsJsonAsync<TimeLogPolicy>("GeneralPolicy/PostTimeLogPolicy", tl);
            //if (result.IsSuccessStatusCode)
            //{
            //    string res = await result.Content.ReadAsStringAsync();

            //    return new Response
            //    {
            //        StatusCode = 200,
            //        Value = "Record was successfully added."
            //    };
            //    //return (data);
            //} else
            //{
            //    return new Response
            //    {
            //        StatusCode = 404,
            //        Value = "Record was successfully added."
            //    };
            //}
            ///
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<AppliedPremiumsPolicy>> GetPremiums()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AppliedPremiumsPolicy>>("GeneralPolicy/GetAppliedPremiums");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }

        public async Task<Response> UpdateAppliedPremiums(AppliedPremiumsModel premiums)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("GeneralPolicy/UpdatePremium", premiums);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<GeneralPolicyDateView>> GetPhilHealthDates()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GeneralPolicyDateView>>("GeneralPolicy/GetPhilHealthDates");
            return result;
        }

        public async Task<List<GeneralPolicyDateView>> GetHdmfDates()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GeneralPolicyDateView>>("GeneralPolicy/GetHdmfDates");
            return result;
        }

        public async Task<List<GeneralPolicyDateView>> GetSssDates()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GeneralPolicyDateView>>("GeneralPolicy/GetSssDates");
            return result;
        }

        public async Task<List<GeneralPolicyDateView>> GetGsisDates()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GeneralPolicyDateView>>("GeneralPolicy/GetGsisDates");
            return result;
        }

        public async Task<List<GeneralPolicyDateView>> GetTaxDates()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GeneralPolicyDateView>>("GeneralPolicy/GetTaxDates");
            return result;
        }

        public async Task<StepIncrementPolicy> GetStepIncrement()
        {
            var result = await _httpClient.GetFromJsonAsync<StepIncrementPolicy>("GeneralPolicy/GetStepIncrement");
            return result;
        }

        public async Task<Response> UpdateStepIncrement(StepIncrementPolicy inc)
        {
            var result = await _httpClient.PostAsJsonAsync("GeneralPolicy/UpdateStepIncrement", inc);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
