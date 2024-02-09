using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace HRMSv4.Client.Service
{
    public class PlacementService : IPlacement 
    {
        private readonly HttpClient _httpClient;
        public PlacementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> ApproveNewEmployee(NewEmployeeApproveV2 newEmployee)
        {
            var result = await _httpClient.PostAsJsonAsync($"Placement/ApproveNewEmployee", newEmployee);
            Response res = new Response
            {
                StatusCode = result.IsSuccessStatusCode ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest,
                Value = result.IsSuccessStatusCode ?  "Success" : "Please fill all the required fields" 
            };
            return res;
        }

        public async Task<Response> DisapproveNewEmployee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>($"Placement/DisapproveNewEmployee/{id}");
            return result;
        }

        public async Task<PersonnelActionMemo> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PersonnelActionMemo>($"Placement/{id}");
            return result;
        }

        public async Task<IEnumerable<PamDemotionEmployeeListView>> GetDemotionEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamDemotionEmployeeListView>>($"Placement/GetDemotionEmployeesAll/{status}");
            return result;
        }

        public async Task<IEnumerable<PamNewEmployeeListView>> GetNewEmployees(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamNewEmployeeListView>>($"Placement/GetNewEmployeesAll/{status}");
            return result;
        }

        public async Task<IEnumerable<PamPromotionEmployeeListView>> GetPromotionEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamPromotionEmployeeListView>>($"Placement/GetPromotionEmployeesAll/{status}");
            return result;
        }

        public async Task<HttpResponseMessage> ApprovePromotion(PromotionApprovedV2 promotion)
        {
            var result = await _httpClient.PostAsJsonAsync("Placement/ApprovePromotion", promotion);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                //throw new Exception(await result.Content.ReadAsStringAsync());
                string a  = await result.Content.ReadAsStringAsync();
                return result;
            }
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PamTransferEmployeeListView>> GetTransferEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamTransferEmployeeListView>>($"Placement/GetTransferEmployeesAll/{status}");
            return result;
        }

        public async Task<Response> Disapprove(int id, string userId)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>("Placement/Disapprove?id=" + id + "&userId=" + userId);
            return result;
        }

        public async Task<Response> DisapproveAll(List<int> memos, string userId)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Placement/DisapproveAll?userId=" + userId, memos);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
                //var result = await _httpClient.PostAsJsonAsync<Response>("/api/Placement/DisapproveAll?memos=" + memos + "&userId=" + userId);
                //return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RenewalEmployeeListView>> GetRenewalEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<RenewalEmployeeListView>>($"Placement/GetRenewalEmployeesAll/{status}");
            return result;
        }

        public async Task<Response> ApproveAll(PersonnelActionMemoDates memos)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Placement/ApproveAll", memos);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmpSeparationList>> GetSeparationEmployees(string sepStatus)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<EmpSeparationList>>($"Placement/GetSeparationEmployees/{sepStatus}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        public async Task<IEnumerable<ReemploymentListView>> GetReemployment(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ReemploymentListView>>($"Placement/GetReemployment/{status}");
            return result;
        }

        public async Task<HttpResponseMessage> StatusRequested(EmpSeparationList sep)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("Placement/StatusRequested", sep);
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
                return result.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<HttpResponseMessage> ApproveReemployment(ReemploymentApproved memo)
        {
            var result = await _httpClient.PostAsJsonAsync($"Placement/ApproveReemployment", memo);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ReElectionListView>> GetReelectionEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ReElectionListView>>($"Placement/GetReelectionEmployeesAll/{status}");
            return result;
        }

        public async Task<HttpResponseMessage> ApproveReelection(ReElectionApproved reelection)
        {
            var result = await _httpClient.PostAsJsonAsync($"Placement/ApproveReelection", reelection);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ReappointmentEmployeeListView>> GetReappointedEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<ReappointmentEmployeeListView>>($"Placement/GetReappointedEmployeesAll/{status}");
            return result;
        }

        public async Task<HttpResponseMessage> ApproveReappointment(ReappointmentApproved reappoint)
        {
            var result = await _httpClient.PostAsJsonAsync($"Placement/ApproveReappointment", reappoint);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PamSalaryAdjustmentListView>> GetSalaryAdjustmentEmployeesAll(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamSalaryAdjustmentListView>>($"Placement/GetSalaryAdjustmentEmployeesAll/{status}");
            return result;
        }

        public async Task<HttpResponseMessage> ApproveSalaryAdjustment(SalaryAdjustmentApprovedV2 sal)
        {
            var result = await _httpClient.PostAsJsonAsync($"Placement/ApproveSalaryAdjustment", sal);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<List<PamStepIncrementListView>> GetStepIncrement(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PamStepIncrementListView>>($"Placement/GetStepIncrement?status="+status);
            return result;
        }

        public async Task<Response> PostApproveStepIncrement(StepIncrementListModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("Placement/PostApproveStepIncrement", model);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
