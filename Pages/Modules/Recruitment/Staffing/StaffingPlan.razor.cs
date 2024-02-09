using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using DevExpress.Blazor;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Shared.Modals.RecruitmentModals;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System.Linq.Dynamic.Core;


namespace HRMSv4.Client.Pages.Modules.Recruitment.Staffing
{
    public partial class StaffingPlan
    {
        #region Declarations
        [Parameter] public string? staffYearId { get; set; }
        [Inject] public NavigationManager? NavigationManager { get; set; }
        [Inject] SweetAlertService? Swal { get; set; }
        [Inject] IJSRuntime? JSRuntime { get; set; }
        [Inject] ILevelOrganization? _IlevelOrganization { get; set; }
        [Inject] IStaffing? staffingService { get; set; }
        [CascadingParameter] public IModalService? Modal { get; set; }
        [Parameter] public StaffingPlanView? selectedPlantillaItem { get; set; }

        GridDevExtremeDataSource<StaffingPlanView> gridDevExtremeDataSource;

        IEnumerable<StaffingPlanView>? plantillaListdata;

        int planId = 0;
        int totalCount = 0;

        string counter = "Please wait while loading data...";
        string userId = "";
        string userName = "";

        object? objectToLoad;
        object? Data { get; set; }

        public string sortBy { get; set; } = "ACTIVE ITEMS";
        public string arrangeBy { get; set; } = "Item Number";
        //public string department { get; set; } = "0";
        public SelectListItems department { get; set; }
        private int yearTo { get; set; }
        public bool isPreviewPrint { get; set; } = false;
        DateTime DateTimeValue { get; set; } = DateTime.Today;
        IGrid? MyGrid { get; set; }


        private List<SelectListItems> _highestLevel { get; set; } = new List<SelectListItems>();
        List<int> Year = new List<int>();
        List<StaffingPlanView> positionItemViews = new List<StaffingPlanView>();
        #endregion


        protected override async Task OnInitializedAsync()
        {
            var user = (await _AutService.GetAuthenticationStateAsync()).User;
            userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value!;
            userName = user.FindFirst(c => c.Type.Contains("givenname"))?.Value;

            _highestLevel = await _IlevelOrganization!.GetHighestLevel();
            department = _highestLevel.FirstOrDefault();
            objectToLoad = _highestLevel;
            int maxY = DateTime.Now.Year + 11;
            int decryptedParam = int.Parse(_crypto.ConvertHexToString(staffYearId!, System.Text.Encoding.Unicode));
            var getPlan = await staffingService!.GetStaffPlan(decryptedParam);
            yearTo = getPlan.Year;
            await GetData();
        }
        async Task GetData()
        {
            int decryptedParam = int.Parse(_crypto.ConvertHexToString(staffYearId!, System.Text.Encoding.Unicode));
            var getPlan = await staffingService!.GetStaffPlan(decryptedParam);
            planId = getPlan != null && getPlan.StaffingPlanId > 0 ? getPlan.StaffingPlanId : 0;

            string tempOrgLvlId = "0";

            if (department != null) tempOrgLvlId = department.Value;

            var queryList = await staffingService.GetStaffingList(tempOrgLvlId, planId);
            plantillaListdata = queryList.ToList();
            //var qList = queryList.AsQueryable();
            gridDevExtremeDataSource = new GridDevExtremeDataSource<StaffingPlanView>(plantillaListdata.AsQueryable());
            gridDevExtremeDataSource.CustomizeLoadOptions = (loadOptions) =>
            {
                loadOptions.PrimaryKey = new[] { "PositionItemId" };
                loadOptions.PaginateViaPrimaryKey = true;
            };
            Data = gridDevExtremeDataSource;
            StateHasChanged();
        }
        async Task ShowPlantillaModal(StaffingPlanView data)
        {
            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,
                Animation = ModalAnimation.FadeIn(0.2),
            };
            var parameters = new ModalParameters();
            if (data != null)
            {
                parameters.Add(nameof(StaffingModal.selectedTempItem), data);
            }
            parameters.Add(nameof(StaffingModal.nextYear), yearTo);
            var formModal = data != null ? Modal!.Show<StaffingModal>("Update Staff ", parameters, options) : Modal!.Show<StaffingModal>("Add Staff ", parameters, options);
            var result = await formModal.Result;
            if (result.Cancelled == false)
            {
                GetData();
            }
        }
        async Task AbolishItem(StaffingPlanView data)
        {
            SweetAlertResult result = await Swal!.FireAsync(new SweetAlertOptions
            {
                Title = "Are you sure?",
                Text = "Do you really want to undo this record?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No",
                CancelButtonColor = "#999999"
            });
            if (!string.IsNullOrEmpty(result.Value))
            {
                if (data.StaffingPlanItemId > 0)
                {
                    var response = await staffingService!.Delete(data.StaffingPlanItemId);
                    if (response.StatusCode == 200)
                    {
                        await _Swal.FireAsync("Success", response.Value, "success");
                        GetData();
                    }
                    else
                    {
                        await _Swal.FireAsync("Warning", response.Value, "warning");
                    }
                }
            }
        }
        async void OnDeptSelect(SelectListItems item)
        {
            department = item;
            await GetData();
        }

        async Task GenerateStaffing()
        {
            try
            {
                var options = new ModalOptions()
                {
                    DisableBackgroundCancel = true,
                    Animation = ModalAnimation.FadeIn(0.2),
                };
                StaffingPlanSignatoryView signatorySelected = new StaffingPlanSignatoryView();
                var data = plantillaListdata!.FirstOrDefault();
                var selectedPlan = data!.StaffingPlanId > 0 ? await staffingService!.GetStaffPlan(data.StaffingPlanId) : null;
                signatorySelected.PreparedByEmployeeId = selectedPlan != null && selectedPlan.PreparedByEmployeeId.HasValue != false ? selectedPlan.PreparedByEmployeeId.Value : 0;
                signatorySelected.ApprovedByEmployeeId = selectedPlan != null && selectedPlan.ApprovedByEmployeeId.HasValue != false ? selectedPlan.ApprovedByEmployeeId.Value : 0;
                signatorySelected.StaffPlanId = data.StaffingPlanId;
                var parameters = new ModalParameters();
                parameters.Add(nameof(StaffingSignatoryModal.staffingPlanSignatory), signatorySelected);
                var formModal = Modal!.Show<StaffingSignatoryModal>("Select Signatory ", parameters, options);
                var result = await formModal.Result;
                if (result.Cancelled == false)
                {
                    await _Swal.FireAsync(new SweetAlertOptions
                    {
                        Title = "Loading...",
                        Html = "Please wait a moment...",
                        ShowConfirmButton = false,
                        AllowOutsideClick = false,
                        Timer = 6000,
                        TimerProgressBar = true
                    });

                    Data = null;
                    objectToLoad = null;
                    Response res = new Response();
                    var plantillaTempList = await staffingService!.GetStaffingList("0", planId);
                    totalCount = plantillaTempList.Count();
                    if (totalCount > 0)
                    {
                        for (int i = 0; i < totalCount; i++)
                        {
                            var row = plantillaTempList.ToList()[i];
                            row.UserId = userId;
                            row.PlantillaYear = yearTo;
                            res = await staffingService.GenerateStaff(row);
                            counter = string.Format("Creating {0:n0} of {1:n0} staffing item(s)...", i + 1, totalCount);
                            StateHasChanged();
                        }
                        await Task.Delay(1000);
                        counter = "Please wait while loading data...";
                        StateHasChanged();
                        await _Swal.FireAsync("Success", "Staffing plan successfully generated.", "success");
                        signatorySelected.StaffPlanId = planId;
                        await staffingService.StaffPlanUpdate(signatorySelected);
                        objectToLoad = await staffingService.GetStaffingList("0", planId);
                        GetData();
                        var psgcCode = await localStorage.GetItemAsync<string>("AdminPsgcCode");

                        string arrayOfParemeters = yearTo.ToString() + "," + userName + "," + psgcCode;
                        string _encryptedParameter = _crypto.ConvertStringToHex(arrayOfParemeters, System.Text.Encoding.Unicode);
                        string url = $"/viewer/{"StaffingPlanReport"}/{_encryptedParameter}";
                        await JSRuntime!.InvokeAsync<object>("open", url, "_blank");
                    }
                    else
                    {
                        await Swal!.FireAsync("Warning", "Staffing list is empty", "warning");
                    }
                }
            }
            catch (Exception ex)
            {
                await Swal!.FireAsync("Error", ex.Message, "error");
            }
        }
        async void printData()
        {
            var psgcCode = await localStorage.GetItemAsync<string>("AdminPsgcCode");
            var user = (await _AutService.GetAuthenticationStateAsync()).User;
            string userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
            string username = "";
            username = user.FindFirst(c => c.Type.Contains("givenname"))?.Value;
            string arrayOfParemeters = yearTo.ToString() + "," + username + "," + psgcCode;
            string _encryptedParameter = _crypto.ConvertStringToHex(arrayOfParemeters, System.Text.Encoding.Unicode);
            string url = $"/viewer/{"StaffingPlanReport"}/{_encryptedParameter}";
            await JSRuntime!.InvokeAsync<object>("open", url, "_blank");
        }
      
    }
}
