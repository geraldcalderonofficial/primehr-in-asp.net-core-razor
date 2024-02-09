using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Shared.Modals.Examination;
using HRMSv4.Shared;
using HRMSv4.Shared.Exam;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Line;
using Radzen;
using Radzen.Blazor;

namespace HRMSv4.Client.Pages.Dashboard.EmployeeContent
{
    public partial class EmployeeDashboard
    {

        [Parameter]
        public int EmployeeId { get; set; }

        [Inject]
        IExam examService { get; set; }

        [Inject] IJobVacancies jobService { get; set; }

        [Inject] Blazored.LocalStorage.ILocalStorageService _localStorage { get; set; }

        [Inject] AuthenticationStateProvider AuthenticationServices { get; set; }

        [CascadingParameter] public IModalService Modal { get; set; }

        private LineChartConfig _config1;
        private Chart _chart1;
        private IJSRuntime _js;
        private bool isHidden = false;
        List<EmployeeExamView> exams = new List<EmployeeExamView>();
        List<EmployeeExamView> submittedExams = new List<EmployeeExamView>();
        public static class LineDataExamples
        {
            public static List<string> SimpleLineText = new List<string>() { "January", "February", "March", "Aprl", "May", "June", "July" };
            public static List<decimal> SimpleLine = new List<decimal>() { 65, 59, 80, 81, 56, 55, 40 };
            public static List<decimal> SimpleLine2 = new List<decimal>() { 33, 25, 35, 51, 54, 76, 45 };
        }

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                var user = (await _AutService.GetAuthenticationStateAsync()).User;
                string role = user.FindFirst(c => c.Type.Contains("role"))?.Value;

                if (role == "Administrator")
                {
                    isHidden = true;
                }

                if (EmployeeId > 0)
                {
                    exams = await examService.GetEmployeeExams(EmployeeId);
                    submittedExams = await examService.GetSubmittedExams(EmployeeId);
                }
                else
                {
                    var empEncryptId = await _localStorage.GetItemAsync<string>(">>redd");
                    if (!string.IsNullOrEmpty(empEncryptId))
                    {
                        string empDecrypted = _crypto.ConvertHexToString(empEncryptId, System.Text.Encoding.Unicode);

                        exams = await examService.GetEmployeeExams(int.Parse(empDecrypted));
                        submittedExams = await examService.GetSubmittedExams(int.Parse(empDecrypted));
                    }
                }

                StateHasChanged();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static class Colors
        {
            public static List<string> Palette1 = new List<string>()
            {
                "rgba(255, 99, 132, 0.2)",
                "rgba(255, 159, 64, 0.2)",
                "rgba(255, 205, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(54, 162, 235, 0.2)",
                "rgba(153, 102, 255, 0.2)",
                "rgba(201, 203, 207, 0.2)"
            };

            public static List<string> PaletteBorder1 = new List<string>()
            {
                "rgb(255, 99, 132)",
                "rgb(255, 159, 64)",
                "rgb(255, 205, 86)",
                "rgb(75, 192, 192)",
                "rgb(54, 162, 235)",
                "rgb(153, 102, 255)",
                "rgb(201, 203, 207)"
            };
        }

        RadzenScheduler<AppointmentExample> scheduler;
        Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        public class AppointmentExample
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Text { get; set; }
        }

        IList<AppointmentExample> appointments = new List<AppointmentExample>
    {
        new AppointmentExample { Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Birthday" },
        new AppointmentExample { Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "Day off" },
        new AppointmentExample { Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "Work from home" },
        new AppointmentExample { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(12), Text = "Online meeting" },
        new AppointmentExample { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(13), Text = "Skype call" },
        new AppointmentExample { Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(14).AddMinutes(30), Text = "Dentist appointment" },
        new AppointmentExample { Start = DateTime.Today.AddDays(1), End = DateTime.Today.AddDays(12), Text = "Vacation" },
    };

        void OnSlotRender(SchedulerSlotRenderEventArgs args)
        {
            // Highlight today in month view
            if (args.View.Text == "Month" && args.Start.Date == DateTime.Today)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }

            // Highlight working hours (9-18)
            if ((args.View.Text == "Week" || args.View.Text == "Day") && args.Start.Hour > 8 && args.Start.Hour < 19)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }
        }

        async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
        {


            //Appointment data = await DialogService.OpenAsync<AddAppointmentPage>("Add Appointment",
            //    new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End } });

            //if (data != null)
            //{
            //    appointments.Add(data);
            //    // Either call the Reload method or reassign the Data property of the Scheduler
            //    await scheduler.Reload();
            //}
        }

        async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<AppointmentExample> args)
        {
            //await DialogService.OpenAsync<EditAppointmentPage>("Edit Appointment", new Dictionary<string, object> { { "Appointment", args.Data } });
            await scheduler.Reload();
        }

        void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<AppointmentExample> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.Text == "Birthday")
            {
                args.Attributes["style"] = "background: red";
            }
        }

        async Task TakeExam(int jobId, int applicationId)
        {
            var user = (await _AutService.GetAuthenticationStateAsync()).User;
            var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;

            if (jobId == 0)
            {
                return;
            }

            SweetAlertResult result = await _Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Please confirm",
                Text = "Do you really want to take the exam?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No",
                CancelButtonColor = "#999999"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                var empEncryptId = await _localStorage.GetItemAsync<string>(">>redd");

                string empDecrypted = _crypto.ConvertHexToString(empEncryptId, System.Text.Encoding.Unicode);

                var data = new ApplicantExamListView
                {
                    EmployeeId = int.Parse(empDecrypted),
                    JobVacancyId = jobId,
                    userId = userId
                };

                if (applicationId > 0)
                {
                    return;
                }

                Response res = await jobService.TakeExam(data);

                if (res.StatusCode == 200)
                {
                    if (res.Value == "")
                    {
                        return;
                    }
                    int applicantExamId = int.Parse(res.Value);

                    SelectedApplicantExamView selectedApplicantExamView = new SelectedApplicantExamView();

                    selectedApplicantExamView.ApplicantExamId = applicantExamId;
                    selectedApplicantExamView.UserId = userId;

                    await examService.BeginExam(selectedApplicantExamView);

                    var options = new ModalOptions()
                    {
                        DisableBackgroundCancel = true,
                        Animation = ModalAnimation.FadeIn(0.2),
                        HideCloseButton = true,
                        ContentScrollable = true,
                    };

                    var parameters = new ModalParameters();
                    parameters.Add(nameof(Intro.ApplicantExamId), applicantExamId);

                    var formModal = Modal.Show<Intro>("Assessment", parameters, options);
                    var resultForm = await formModal.Result;

                    if (resultForm.Cancelled == false)
                    {
                        exams = await examService.GetEmployeeExams(int.Parse(empDecrypted));
                        submittedExams = await examService.GetSubmittedExams(int.Parse(empDecrypted));

                        var resValue = (int)resultForm.Data;

                        var AppData = new SelectedApplicantExamView
                        {
                            ApplicantExamId = resValue,
                            UserId = userId
                        };

                        await examService.UpdateApplicantExam(AppData);

                        StateHasChanged();
                    }
                }
            }
        }

        async Task ContinueExam(int jobId, int applicationId, int currentRow)
        {
            var empEncryptId = await _localStorage.GetItemAsync<string>(">>redd");

            string empDecrypted = _crypto.ConvertHexToString(empEncryptId, System.Text.Encoding.Unicode);

            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,
                Animation = ModalAnimation.FadeIn(0.2),
                HideCloseButton = true,
                ContentScrollable = true
            };

            var parameters = new ModalParameters();
            parameters.Add(nameof(Intro.ApplicantExamId), applicationId);

            currentRow = currentRow > 0 ? currentRow - 1 : 0;
            parameters.Add(nameof(Intro.CurrentRow), currentRow);
            //get latest page

            var formModal = Modal.Show<Intro>("Assessment", parameters, options);
            var resultForm = await formModal.Result;

            if (resultForm.Cancelled == false)
            {

                exams = await examService.GetEmployeeExams(int.Parse(empDecrypted));
                submittedExams = await examService.GetSubmittedExams(int.Parse(empDecrypted));

                StateHasChanged();
            }
        }
    }
}
