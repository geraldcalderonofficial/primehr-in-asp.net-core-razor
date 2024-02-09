using Blazored.LocalStorage;
using Blazored.Modal;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Shared.Modals;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.Chartjs.Models.Line;
using PSC.Blazor.Components.Chartjs;
using Microsoft.AspNetCore.Components.Authorization;
using HRMSv4.Client.Provider;
using HRMSv4.Client.Interface.Auth;

namespace HRMSv4.Client.Pages.Dashboard
{
    public partial class Administrator
    {
        [Inject]
        ICompanyProfile companyService { get; set; }

        [Inject]
        IAuthenticationService _auth { get; set; }

        [Inject]
        ILevel levelService { get; set; }

        [Inject]
        ILocalStorageService _localStorage { get; set; }

        private string _currentYear { get; set; }
        private string _nextYear { get; set; }

        bool _isLoading { get; set; }

        SystemParameterViewModel parameterModel = new SystemParameterViewModel();
        IEnumerable<HRMSv4.Shared.OnBoarding.Level> levelModel;

        //[Parameter] 
        public int EmployeeCurrentYearCount { get; set; }
        //[Parameter] 
        public int EmployeeNextYearCount { get; set; }
        //[Parameter] 
        public int EmployeeTotalCount { get; set; }
        //[Parameter] 
        public int EmployeeMaleCount { get; set; }
        //[Parameter] 
        public int EmployeeFemaleCount { get; set; }
        //[Parameter] 
        public int NewEmployeeCount { get; set; }
        //[Parameter] 
        public int StepIncrementCount { get; set; }
        //[Parameter] 
        public int PromotionCount { get; set; }
        //[Parameter] 
        public int SalaryAdjustmentCount { get; set; }
        //[Parameter] 
        public int RenewalCount { get; set; }
        //[Parameter] 
        public int TransferCount { get; set; }
        //[Parameter] 
        public int DemotionCount { get; set; }
        //[Parameter] 
        public int SeparationCount { get; set; }
        //[Parameter] 
        public int OnTimeCount { get; set; }
        //[Parameter] 
        public int TardyCount { get; set; }
        //[Parameter] 
        public int AbsentCount { get; set; }
        //[Parameter] 
        public int OnLeaveCount { get; set; }
        //[Parameter] 
        public int TravelOrderCount { get; set; }
        //[Parameter] 
        public int EmployeesWorkCount { get; set; }

        private LineChartConfig _config1;
        private Chart _chart1;

        public static class LineDataExamples
        {
            public static List<string> SimpleLineText = new List<string>() { "January", "February", "March", "Aprl", "May", "June", "July" };
            public static List<decimal> SimpleLine = new List<decimal>() { 65, 59, 80, 81, 56, 55, 40 };
            public static List<decimal> SimpleLine2 = new List<decimal>() { 33, 25, 35, 51, 54, 76, 45 };
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

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var user = (await _AutService.GetAuthenticationStateAsync()).User;
                string userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;

                if (!user.Identity.IsAuthenticated)
                {
                    _navigation.NavigateTo("/");
                }

                _isLoading = true;

                parameterModel = new SystemParameterViewModel();
                parameterModel = await companyService.Get(userId);

                levelModel = await levelService.GetAll();

                var getHighestParent = levelModel.FirstOrDefault(c => c.ParentId == 0);

                if (getHighestParent == null)
                {
                    ShowModal();
                }

                DateTime now = DateTime.Now;
                _currentYear = now.Year.ToString();
                _nextYear = (now.Year + 1).ToString();

                _config1 = new LineChartConfig()
                {
                };

                _config1.Data.Labels = LineDataExamples.SimpleLineText;
                _config1.Data.Datasets.Add(new LineDataset()
                {
                    Label = "My First Dataset",
                    Data = LineDataExamples.SimpleLine.ToList(),
                    BorderColor = Colors.PaletteBorder1.FirstOrDefault(),
                    Tension = 0.1M,
                    Fill = false
                });
            }
            catch (Exception e)
            {
                var user = (await _AutService.GetAuthenticationStateAsync()).User;
                string userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;

                await _authInterfaceService.Logout(userId);
            }
        }

        void ShowModal()
        {
            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,
                Animation = ModalAnimation.FadeIn(0.2),
                ContentScrollable = true,
                HideCloseButton = true
            };

            Modal.Show<ProfileModal>("Company Profile", options);
        }
    }
}
