using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using DevExpress.Blazor;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Shared.Modals;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;
using System.Linq.Dynamic.Core;

namespace HRMSv4.Client.Pages.Modules
{
    public partial class PlantillaRecordEntries
    {


        
        [Inject] SweetAlertService Swal { get; set; }
        [Inject] IPlantilla plantillaService { get; set; }
        [Inject] ILevelOrganization _IlevelOrganization { get; set; }
        [CascadingParameter] public IModalService Modal { get; set; }

        private List<SelectListItems> _highestLevel { get; set; } = new List<SelectListItems>();

        string counter = "Loading...";
        string userId = "";
        bool isLoading = true;
        int totalCount = 0;

        IEnumerable<PlantillaRecordView> plantillaListdata;
        IEnumerable<PlantillaRecordView> plantillaListdataTemp;
        GridDevExtremeDataSource<PlantillaRecordView>? gridDevExtremeDataSource;

        IGrid? MyGrid { get; set; }
        object? Data { get; set; }
        string sortBy { get; set; } = "ACTIVE ITEMS";
        string arrangeBy { get; set; } = "Item Number";
        string department { get; set; } = "0";
        int yearTo { get; set; }

        void OnDeptSelect(string item)
        {
            department = item;
            plantillaListdata = plantillaListdataTemp;
            plantillaListdata = department != "---Select Level---" ? plantillaListdata.Where(c => c.Department.ToLower().Contains(department.ToLower())) : plantillaListdataTemp;
            Data = plantillaListdata;
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            var user = (await _AutService.GetAuthenticationStateAsync()).User;
            userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
            var response = await plantillaService.PlantillaYear(userId);

            var isGenerated = await CheckPlantilla();

            if (isGenerated == true)
            {
                await Swal.FireAsync("Warning", "All items are recreated this year. Creating another set is unnecessary.", "warning");
                _navigation.NavigateTo("module-plantilla", true);
                return;
            }

            if (response.StatusCode != 200)
            {
                List<PlantillaRecordView> list = new List<PlantillaRecordView>();
                plantillaListdataTemp = list;
                plantillaListdata = list;
                await Swal.FireAsync("Warning", "Please set plantilla year", "warning");
                _navigation.NavigateTo("policies", true);
                return;
            }

            var queryList = await plantillaService.GetPlantillaList(sortBy, arrangeBy, department);
            plantillaListdataTemp = queryList;
            gridDevExtremeDataSource = new GridDevExtremeDataSource<PlantillaRecordView>(queryList.AsQueryable());
            gridDevExtremeDataSource.CustomizeLoadOptions = (loadOptions) =>
            {
                loadOptions.PrimaryKey = new[] { "PositionItemId" };
                loadOptions.PaginateViaPrimaryKey = true;
            };
            Data = gridDevExtremeDataSource;


            _highestLevel = await _IlevelOrganization.GetHighestLevel();

            int yearActive = response.StatusCode == 200 ? int.Parse(response.Value) : DateTime.Now.Year;
            yearTo = yearActive;

            StateHasChanged();
        }
        async Task AbolishItem(PlantillaRecordView data)
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Do you want to abolish the selected item?",
                Text = "Please check information before Submiting!",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No",
                CancelButtonColor = "#999999"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                if (data.PositionItemId > 0)
                {
                    var selectedItem = plantillaListdataTemp.FirstOrDefault(c => c.PositionItemId == data.PositionItemId);
                    selectedItem.MovementType = "Abolished";
                    selectedItem.ItemNumber = selectedItem.ItemNumber + " (Abolished)";
                    plantillaListdata = plantillaListdataTemp;
                }
                else
                {
                    var plantillaTempList = plantillaListdataTemp.ToList();
                    plantillaTempList.Remove(data);
                    plantillaListdata = plantillaTempList;
                }
                Data = plantillaListdata;
                StateHasChanged();
            }
        }
        async Task ShowPlantillaModal(int id, PlantillaRecordView data)
        {
            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,
                Animation = ModalAnimation.FadeIn(0.2),
            };
            var parameters = new ModalParameters();
            parameters.Add(nameof(PlantillaRecordModal.selectedTempItem), data);

            var formModal = data != null && data.ItemNumber != "" ? Modal.Show<PlantillaRecordModal>("Update Plantilla ", parameters, options) : Modal.Show<PlantillaRecordModal>("Add Plantilla ", options);
            var result = await formModal.Result;

            var tempObj = result.Data as PlantillaRecordView;

            if (data != null)
            {
                var selectedItem = plantillaListdataTemp.FirstOrDefault(c => c.ItemNumber == data.ItemNumber);
                selectedItem.ItemNumber = tempObj.ItemNumber;
                selectedItem.Position = tempObj.Position;
                selectedItem.PositionId = tempObj.PositionId;
                selectedItem.ItemNumber = tempObj.ItemNumber;
                selectedItem.DateAdded = tempObj.DateAdded;
                selectedItem.AuthorizedSalary = tempObj.AuthorizedSalary;
                selectedItem.SalaryGradeNumber = tempObj.SalaryGradeNumber;
                selectedItem.SalaryGradeId = tempObj.SalaryGradeId;
                selectedItem.Department = tempObj.Department;
                selectedItem.OrganizationLevelId = tempObj.OrganizationLevelId;

                Data = plantillaListdataTemp;
            }
            else
            {
                var plantillaTempList = plantillaListdataTemp.ToList();

                plantillaTempList.Add(tempObj);

                plantillaListdataTemp = plantillaTempList;
                Data = plantillaListdataTemp;
            }
            StateHasChanged();
        }
        async Task ShowScrapBuildModal(PlantillaRecordView data)
        {
            try
            {
                var options = new ModalOptions()
                {
                    DisableBackgroundCancel = true,
                    Animation = ModalAnimation.FadeIn(0.2),
                    ContentScrollable = true,
                };
                var parameters = new ModalParameters();
                parameters.Add(nameof(ScrapBuildPlantillaModal.selectedTempItem), data);
                if (data.PositionItemId > 0)
                {
                    var formModal = Modal.Show<ScrapBuildPlantillaModal>("Scrap and Build Plantilla Item ", parameters, options);
                    var result = await formModal.Result;
                    if (result.Cancelled == false)
                    {
                        var tempObj = result.Data != null ? result.Data as List<PlantillaRecordView> : new List<PlantillaRecordView>();
                        if (tempObj.Count() > 0)
                        {
                            var duplicateItemNumbersPerDepartment = (from listItem in plantillaListdataTemp
                                                                     join item in tempObj on new { listItem.ItemNumber, listItem.OrganizationLevelId } equals new { item.ItemNumber, item.OrganizationLevelId }
                                                                     where listItem.MovementType != "Abolished"
                                                                     select listItem).ToList();
                            var itemToScrap = duplicateItemNumbersPerDepartment.FirstOrDefault(c => c.ItemNumber == data.ItemNumber && c.Department == data.Department);
                            duplicateItemNumbersPerDepartment.Remove(itemToScrap);
                            while (duplicateItemNumbersPerDepartment.Count() > 0)
                            {
                                await Swal.FireAsync("Warning", string.Format("Please update item numbers of detected duplicate entries:\n{0}", String.Join(", ", duplicateItemNumbersPerDepartment.Select(c => c.ItemNumber).ToList())), "warning");
                                var formModal2 = Modal.Show<ScrapBuildPlantillaModal>("Scrap and Build Plantilla Item ", parameters, options);
                                var result2 = await formModal2.Result;
                                tempObj = result2.Data != null ? result2.Data as List<PlantillaRecordView> : new List<PlantillaRecordView>();
                                duplicateItemNumbersPerDepartment = (from listItem in plantillaListdataTemp
                                                                     join item in tempObj on new { listItem.ItemNumber, listItem.Department } equals new { item.ItemNumber, item.Department }
                                                                     where listItem.IsDeleted == false
                                                                     select listItem).ToList();
                                itemToScrap = duplicateItemNumbersPerDepartment.FirstOrDefault(c => c.ItemNumber == data.ItemNumber && c.Department == data.Department);
                                duplicateItemNumbersPerDepartment.Remove(itemToScrap);
                            }
                            if (duplicateItemNumbersPerDepartment.Count() == 0)
                            {
                                var selectedItem = plantillaListdataTemp.FirstOrDefault(c => c.PositionItemId == data.PositionItemId);
                                selectedItem.MovementType = "Abolished";
                                selectedItem.ItemNumber = selectedItem.ItemNumber + " (Abolished)";
                                plantillaListdata = plantillaListdataTemp;

                                var allplantillaListdata = plantillaListdataTemp.ToList();
                                allplantillaListdata.AddRange(tempObj);
                                allplantillaListdata = allplantillaListdata.OrderBy(c => c.ItemNumber).ToList();
                                plantillaListdataTemp = allplantillaListdata;
                                Data = plantillaListdataTemp;
                            }
                        }
                        StateHasChanged();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        async Task InsertRow()
        {
            await ShowPlantillaModal(0, null);
        }
        async Task GenerateSetRow()
        {
            try
            {
                isLoading = false;
                await Task.Yield();

                Response res = new Response();
                var plantillaTempList = plantillaListdataTemp.ToList();

                totalCount = plantillaTempList.Count();

                if (totalCount > 0)
                {
                    for (int i = 0; i < totalCount; i++)
                    {
                        var row = plantillaTempList[i];
                        row.UserId = userId;
                        res = await plantillaService.TempPlantilla(row);
                        counter = string.Format("Creating {0:n0} of {1:n0} plantilla item(s)...", i + 1, totalCount);
                        StateHasChanged();
                    }
                    await Task.Delay(2000);
                    counter = "Loading...";
                    isLoading = true;
                    StateHasChanged();
                    await _Swal.FireAsync("Success", "Plantilla records successfully generated for current year.", "success");
                    _navigation.NavigateTo("module-plantilla", true);
                }
                else
                {
                    await Swal.FireAsync("Warning", "Plantilla list is empty", "warning");
                }
            }
            catch (Exception ex)
            {
                await Swal.FireAsync("Error", ex.Message, "error");
            }
        }
        async Task<bool> CheckPlantilla()
        {
            Response res = new Response();
            res = await plantillaService.CheckPlantilla();

            if (res.StatusCode == 200)
            {
                return true;
            }
            else if (res.StatusCode == 404)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        //=== Unused Code due to Migration to DevExpress
        //var newplantillaListdata = plantillaListdata.ToList();
        //newplantillaListdata.AddRange(tempObj);
        //[Inject] IHistoryEntry historyService { get; set; }
        //[Inject] public NavigationManager NavigationManager { get; set; }
        //[Inject] AuthenticationStateProvider AuthenticationServices { get; set; }
        //[CascadingParameter] BlazoredModalInstance ModalInstance { get; set; }
        //[Parameter] public PlantillaRecordView selectedPlantillaItem { get; set; }
        //List<PlantillaRecordView> positionItemViews = new List<PlantillaRecordView>();
        //async Task Reset()
        //{
        //    grid.Reset(true);
        //    await grid.FirstPage(true);
        //}
    }
}
