using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using DevExpress.Blazor;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Shared.Modals;
using HRMSv4.Shared;
using HRMSv4.Shared.Misc;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace HRMSv4.Client.Pages.Modules.Placement
{
    public partial class Reemployment
    {
        IEnumerable<HRMSv4.Shared.OnBoarding.ReemploymentListView> reemploymentListViews;
        IList<HRMSv4.Shared.OnBoarding.ReemploymentListView> selectedEmployees;
        RadzenDataGrid<HRMSv4.Shared.OnBoarding.ReemploymentListView> renewalGrid;
        [CascadingParameter] public IModalService Modal { get; set; }
        [CascadingParameter] BlazoredModalInstance ModalInstance { get; set; }
        [Inject] SweetAlertService Swal { get; set; }
        [Inject] IPlacement placementService { get; set; }

        public string? apiURL { get; set; }
        string status = "";
        bool HideApproval = true;


        List<string> filters = new List<string> { "All", "Pending", "Approved", "Disapproved" };
        string selectedType { get; set; } = "Pending";
        string userId = "";
        object Employees { get; set; }
        GridDevExtremeDataSource<ReemploymentListView> gridDevExtremeDataSource;


        protected override async Task OnInitializedAsync()
        {
            apiURL = AppInfo.ApiUrl;
            //reemploymentListViews = await placementService.GetReemployment("Pending");
            var user = (await _AutService.GetAuthenticationStateAsync()).User;
            userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
            await UpdateDataAsync();
        }

        async Task UpdateDataAsync()
        {
            reemploymentListViews = await placementService.GetReemployment(selectedType);

            var tempList = reemploymentListViews.AsQueryable();
             
            gridDevExtremeDataSource = new GridDevExtremeDataSource<ReemploymentListView>(tempList);
            gridDevExtremeDataSource.CustomizeLoadOptions = (loadOptions) =>
            {
                loadOptions.PrimaryKey = new[] { "PersonnelActionMemoId" };
                loadOptions.PaginateViaPrimaryKey = true;
            };

            Employees = gridDevExtremeDataSource;


            StateHasChanged();
        }

        async Task Filter(string e)
        {
            string a = e;
            status = a;
            HideApproval = a == "Pending" ? true : false;
            //reemploymentListViews = await placementService.GetReemployment(status);
            //await renewalGrid.Reload();
            await UpdateDataAsync();
            this.StateHasChanged();

        }

        async void Approve(ReemploymentListView pam)
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Are you sure?",
                Text = "You are about to approve this reemployment.",
                Icon = "question",
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "Cancel",
                CancelButtonColor = "#dc3741"

            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                var parameters = new ModalParameters();
                parameters.Add(nameof(ApproveReemploymentModal.pamId), pam.PersonnelActionMemoId);
                parameters.Add(nameof(ApproveReemploymentModal.orgLevelId), pam.OrganizationalLevelId);
                var _modalStatus = Modal.Show<ApproveReemploymentModal>("Reemployment", parameters);
                var modalResult = await _modalStatus.Result;
                if (modalResult.Cancelled == false)
                {
                    
                }
            }
        }

        async void Disapprove(ReemploymentListView pam)
        {

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Are you sure?",
                Text = "You are about to disapprove this reemployment.",
                Icon = "question",
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "Cancel",
                CancelButtonColor = "#dc3741"

            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                var user = (await _AutService.GetAuthenticationStateAsync()).User;
                var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;


                var res = await placementService.Disapprove(pam.PersonnelActionMemoId, userId);

                if (res.StatusCode == 200)
                {

                    SweetAlertResult result1 = await Swal.FireAsync(new SweetAlertOptions
                    {
                        Title = "Success",
                        Text = "You have successfully disapprove a reemployment.",
                        Icon = "success",
                        ShowCancelButton = true,
                        ConfirmButtonText = "Ok",
                    });
                    if (!string.IsNullOrEmpty(result.Value))
                    {                        
                        ModalInstance.CloseAsync();
                    }
                }
                else
                {
                    await Swal.FireAsync("Oops...", "Unable to disapprove this record!", "error");
                }
            }
            else
            {

            }
        }
        async void ShowImage(string img)
        {
            await _Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Employee Capture Image",
                ImageUrl = img,
                ImageHeight = 600,
                ImageWidth = 400
            });
        }
    }
}
