using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class StaffingService : IStaffing
    {
        private readonly HttpClient _httpClient;

        public StaffingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(StaffingPlanView positionItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<StaffingPlanView>($"Staffing", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        public async Task<Response> AddStaffPlan(StaffingPlanSignatoryView item)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<StaffingPlanSignatoryView>($"Staffing/AddStaffPlan", item);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> GenerateStaff(StaffingPlanView positionItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Staffing/GenerateStaff", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<StaffingPlanSignatoryView>> GetAllStaffList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<StaffingPlanSignatoryView>>($"Staffing/AllStaffList");
            return result;
        }

        public async Task<IEnumerable<StaffingPlanView>> GetStaffingList(string orgId, int staffId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<StaffingPlanView>>($"Staffing/StaffList?orgId={orgId}&staffId={staffId}");
            return result;
        }

        public async Task<Response> Update(StaffingPlanView positionItem)
        {
            try
            {
                string res = "";
                var result = await _httpClient.PutAsJsonAsync<StaffingPlanView>($"Staffing", positionItem);
                
                if (result.IsSuccessStatusCode)
                {
                     res = await result.Content.ReadAsStringAsync();
                   
                    return new Response
                    {
                        StatusCode = 200,
                        Value = res
                    };

                }
                else
                {
                    res = await result.Content.ReadAsStringAsync();

                    return new Response
                    {
                        StatusCode = 404,
                        Value = res
                    };
                }

                return null;
                    //JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<Response> StaffPlanUpdate(StaffingPlanSignatoryView signatory)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<StaffingPlanSignatoryView>($"Staffing/StaffPlanUpdate", signatory);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Staffing/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<StaffingPlan> GetStaffPlan(int planId)
        {
            var result = await _httpClient.GetFromJsonAsync<StaffingPlan>($"Staffing/StaffPlan?planId={planId}");
            return result;
        }
    }
}
