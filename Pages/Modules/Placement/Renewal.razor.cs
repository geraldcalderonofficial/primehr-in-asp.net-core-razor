using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
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
    public partial class Renewal
    {
        IEnumerable<HRMSv4.Shared.OnBoarding.RenewalEmployeeListView> renewalEmployees;
        IList<HRMSv4.Shared.OnBoarding.RenewalEmployeeListView> selectedEmployees;
        RadzenDataGrid<HRMSv4.Shared.OnBoarding.RenewalEmployeeListView>? renewalGrid;
        [CascadingParameter] public IModalService Modal { get; set; }
        [CascadingParameter] BlazoredModalInstance ModalInstance { get; set; }
        [Inject] SweetAlertService Swal { get; set; }
        [Inject] IPlacement placementService { get; set; }
        public string? apiURL { get; set; }
        string status = "";
        bool HideApproval = true;


        protected override async Task OnInitializedAsync()
        {
            apiURL = AppInfo.ApiUrl;
            renewalEmployees = await placementService.GetRenewalEmployeesAll("Pending");
            if (renewalEmployees.Count() == 0)
            {
                HideApproval = false;
            }
        }

        async Task ClickHandler(string action)
        {
            if (selectedEmployees == null || selectedEmployees.Count == 0)
            {
                return;
            }

            var selectEmployeeList = selectedEmployees.Select(c => new { c.PersonnelActionMemoId }).ToList();
            List<int> memos = selectedEmployees.Select(c => c.PersonnelActionMemoId).ToList();
            if (action == "Approve")
            {
                var user = (await _AutService.GetAuthenticationStateAsync()).User;
                var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;

                if (memos.Count() > 0)
                {
                    
                    var options = new ModalOptions()
                    {
                        DisableBackgroundCancel = true,
                        Animation = ModalAnimation.FadeIn(0.2)
                    };

                    var formModal = Modal.Show<EffectivityDateModal>("Effectivity Date", options);

                    var formResult = await formModal.Result;
                    if (formResult.Cancelled == false)
                    {
                        var dates = formResult.Data as PersonnelActionMemoDates;
                        dates.Memos = memos;
                        dates.UserId = userId;

                        var approvedRenewals = await placementService.ApproveAll(dates);
                        if (approvedRenewals.StatusCode == 200)
                        {
                            await Swal.FireAsync("Success", approvedRenewals.Value, "success");

                            status = status != "" ? status : "Pending";

                            renewalEmployees = await placementService.GetRenewalEmployeesAll(status);
                            selectedEmployees.Clear();
                            renewalGrid.Reset(true);
                            await renewalGrid.FirstPage(true);
                            StateHasChanged();
                        }
                        else
                        {
                            await Swal.FireAsync("Warning", approvedRenewals.Value, "warning");
                        }
                    }

                }

                
            }
            else if(action == "Decline")
            {
                if (selectedEmployees.Count() > 0)
                {
                    SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
                    {
                        Title = "Are you sure?",
                        Text = "You are about to disapprove this renewal/s.",
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


                        var response = await placementService.DisapproveAll(memos, userId);
                        if (response.StatusCode == 200)
                        {
                            await Swal.FireAsync("Success", "Request declined", "success");

                            status = status != "" ? status : "Pending";

                            renewalEmployees = await placementService.GetRenewalEmployeesAll(status);
                            selectedEmployees.Clear();
                            renewalGrid.Reset(true);
                            await renewalGrid.FirstPage(true);
                            StateHasChanged();
                        }
                        else
                        {
                            await Swal.FireAsync("Error", response.Value, "error");
                        }

                        //var res = await placementService.Disapprove(), userId);
                    }
                }
                
            }
        }

        async Task Filter(ChangeEventArgs e)
        {
            string a = e.Value.ToString();
            status = a;            
            renewalEmployees = await placementService.GetRenewalEmployeesAll(status);
            HideApproval = a == "Pending" && renewalEmployees.Count() > 0 ? true : false;
            await renewalGrid.Reload();
            this.StateHasChanged();

        }

        async Task SelectedNewEmployee(RenewalEmployeeListView selectedRow)
        {

        }

        async void Approve(RenewalEmployeeListView pam)
        {
            
        }

        async void Disapprove(RenewalEmployeeListView pam)
        {

            
        }

    }
}
