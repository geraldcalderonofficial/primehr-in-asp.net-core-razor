using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class LeaveApplicationService : ILeaveApplication
    {
        private readonly HttpClient _httpClient;
        public LeaveApplicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> AddLeaveApplication(LeaveApplicationView leaveApplication)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("LeaveApplication/AddLeaveApplication", leaveApplication);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<Response> DeleteLeaveApplication(int leaveApplicationId)
        {
            var result = await _httpClient.DeleteAsync($"LeaveApplication/DeleteLeaveApplication?leaveApplicationId=" + leaveApplicationId);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<LeaveApplicationView> GetLeaveApplication(int leaveApplicationId)
        {
            var result = await _httpClient.GetFromJsonAsync<LeaveApplicationView>("LeaveApplication/GetLeaveApplication/?leaveApplicationId=" + leaveApplicationId);
            return result;
        }

        public async Task<List<LeaveApplicationView>> GetLeaveApplications(string status, DateTime? Start, DateTime? End, int Id)
        {
            string dateStart = Start == null || Start.HasValue == null ? ("1900-01-01") : Start.Value.ToString("yyyy-MM-dd");
            string dateEnd = End == null || End.HasValue == null ? ("1900-01-01") : End.Value.ToString("yyyy-MM-dd");

            var result = await _httpClient.GetFromJsonAsync<List<LeaveApplicationView>>("LeaveApplication/GetLeaveApplications?status=" + status + "&start=" + dateStart + "&end=" + dateEnd + "&Id=" + Id);
            return result;
        }

        public async Task<Response> UpdateLeaveApplication(LeaveApplicationView leaveApplication)
        {
            var result = await _httpClient.PutAsJsonAsync("LeaveApplication/UpdateLeaveApplication", leaveApplication);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> PatchApplication(LeaveApplicationView leaveApplication)
        {
            try
            {
                Response res = new Response();

                var result = await _httpClient.PutAsJsonAsync("LeaveApplication/Approval", leaveApplication);
                if(result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Request Updated."
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
