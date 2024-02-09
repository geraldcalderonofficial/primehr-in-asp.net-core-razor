using HRMSv4.Client.Pages.Dashboard;
using HRMSv4.Shared;
using HRMSv4.Shared.Timekeeping;

namespace HRMSv4.Client.Interface
{
    public interface ISchedule
    {
        Task<List<WeeklySchedule>> GetAllTemplate();
        Task<WeeklySchedule> GetTemplateById(int id);
        Task<Response> AddTemplate(WeeklySchedule ws);
        Task<Response> DeleteTemplate(int id);
        //days
        Task<List<WeeklyScheduleDay>> GetAllDays(int weekId);
        Task<WeeklyScheduleDay> GetDayById(int id);
        Task<Response> AddDay(WeeklyScheduleDay wsd);
        Task<Response> DeleteDay(int id);
        //
        ///Employee schedule
        ///
        Task<List<ScheduleListView>> GetEmployeeSchedule(int orgLevelId, int rateTypeId, DateTime? dt);
        Task<Response> GetHasExistingSchedule(List<ScheduleListView> selectedEmployees);
        Task<Response> AddCustomSchedule(AddCustomListView sched);
        Task<Response> AddNonCustomSchedule(AddNonCustomListView sched);
        //Task<List<ManageScheduleListView>> GetSchedulesOfEmployees(List<ScheduleListView> selectedEmployees);
        //ScheduleList
        Task<List<ManageScheduleListView>> GetSchedulesOfEmployees(ScheduleList scheduleList);
        Task<Response> PostManageSchedule(ManageSchedModel model);
        Task<List<ScheduleDetailListView>> GetScheduleDetail(ScheduleDetailModel model);
        Task<Response> ClearSchedule(ScheduleDetailModel model);
    }
}
