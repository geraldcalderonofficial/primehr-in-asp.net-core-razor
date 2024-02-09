using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.Selection;
using HRMSv4.Shared.Timekeeping;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ScheduleService : ISchedule
    {
        private readonly HttpClient _httpClient;

        public ScheduleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> AddCustomSchedule(AddCustomListView sched)
        {
            var result = await _httpClient.PostAsJsonAsync<AddCustomListView>("Schedule/AddCustomSchedule", sched);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> AddDay(WeeklyScheduleDay wsd)
        {
            var result = await _httpClient.PostAsJsonAsync<WeeklyScheduleDay>($"Schedule/AddDay", wsd);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> AddNonCustomSchedule(AddNonCustomListView sched)
        {
            var result = await _httpClient.PostAsJsonAsync<AddNonCustomListView>("Schedule/AddNonCustomSchedule", sched);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);

        }

        public async Task<Response> AddTemplate(WeeklySchedule ws)
        {
            var result = await _httpClient.PostAsJsonAsync<WeeklySchedule>("Schedule/AddTemplate", ws);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async  Task<Response> DeleteDay(int id)
        {
            var result = await _httpClient.DeleteAsync($"Schedule/DeleteDay?id=" + id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteTemplate(int id)
        {
            var result = await _httpClient.DeleteAsync($"Schedule/DeleteTemplate?id=" + id);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<WeeklyScheduleDay>> GetAllDays(int weekId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<WeeklyScheduleDay>>("Schedule/GetAllDays?weekId=" + weekId);
            return result;
        }

        public async Task<List<WeeklySchedule>> GetAllTemplate()
        {
            var result = await _httpClient.GetFromJsonAsync<List<WeeklySchedule>>("Schedule/GetAllTemplate");
            return result;
        }

        public async Task<WeeklyScheduleDay> GetDayById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<WeeklyScheduleDay>("Schedule/GetDayById?id=" + id);
            return result;
        }

        public async Task<List<ScheduleListView>> GetEmployeeSchedule(int orgLevelId, int rateTypeId, DateTime? dt)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ScheduleListView>>("Schedule/GetEmployeeSchedule?orgLevelId=" + orgLevelId + "&rateTypeId=" + rateTypeId + "&dt=" + dt);
            return result;
        }

        public async Task<Response> GetHasExistingSchedule(List<ScheduleListView> selectedEmployees)
        {
            var result = await _httpClient.PostAsJsonAsync<List<ScheduleListView>>($"Schedule/GetHasExistingSchedule", selectedEmployees);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);

        }

        //public async Task<List<ManageScheduleListView>> GetSchedulesOfEmployees(List<ScheduleListView> selectedEmployees, DateTime dt)
        //{
        //    var result = await _httpClient.PostAsJsonAsync($"/api/Schedule/GetSchedulesOfEmployees?selectedEmployees=" + selectedEmployees + "&dt=" + dt);
        //    string res = await result.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<List<ManageScheduleListView>>(res);
        //}
        public async Task<List<ManageScheduleListView>> GetSchedulesOfEmployees(ScheduleList scheduleList)
        {
            var result = await _httpClient.PostAsJsonAsync($"Schedule/GetSchedulesOfEmployees/", scheduleList);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ManageScheduleListView>>(res);
        }


        public async Task<WeeklySchedule> GetTemplateById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<WeeklySchedule>("Schedule/GetTemplateById?id="+id);
            return result;
        }

        public async Task<Response> PostManageSchedule(ManageSchedModel model)
        {
            var result = await _httpClient.PostAsJsonAsync<ManageSchedModel>("Schedule/PostManageSchedule", model);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<List<ScheduleDetailListView>> GetScheduleDetail(ScheduleDetailModel model)
        {
            var result = await _httpClient.PostAsJsonAsync($"Schedule/GetScheduleDetail", model);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ScheduleDetailListView>>(res);
        }

        public async Task<Response> ClearSchedule(ScheduleDetailModel model)
        {
            var result = await _httpClient.PostAsJsonAsync($"Schedule/ClearSchedule", model);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }

}
