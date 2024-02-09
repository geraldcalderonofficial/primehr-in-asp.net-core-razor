using Blazored.LocalStorage;
using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using HRMSv4.Client;
using HRMSv4.Client.Interface;
using HRMSv4.Client.Interface.Auth;
using HRMSv4.Client.Provider;
using HRMSv4.Client.Service;
using HRMSv4.Client.Service.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using reCAPTCHADemo.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Majorsoft.Blazor.Components.Common.JsInterop;
using HRMSv4.Client.Interface.IProtection;
using HRMSv4.Client.Service.Protection;
using HRMSv4.Client.Interface.File;
using HRMSv4.Client.Service.File;
using HRMSv4.Client.Interface.Workplan;
using HRMSv4.Client.Service.Workplan;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using HRMSv4.Client.Interface.Payroll;
using HRMSv4.Client.Service.Payroll;
using HRMSv4.Client.Interface.Timekeeping;
using HRMSv4.Client.Service.Timekeeping;
using HRMSv4.Client.Interface.Premiums;
using HRMSv4.Client.Service.Premiums;
using HRMSv4.Client.Service.BlockUIService;
using HRMSv4.Client.Interface.Rnr;
using HRMSv4.Client.Service.Rnr;
using HRMSv4.Client.Service.Assessment;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);

string urlAbsolute = Convert.ToString(new Uri(baseAddress.AbsoluteUri + "api/"));

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(urlAbsolute)
}.EnableIntercept(sp));
//.AddBlockUserInterface();

#region SignalR
builder.Services.AddSingleton<HubConnection>(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HubConnectionBuilder()
      .WithUrl(navigationManager.ToAbsoluteUri("/hrmsHub"))
      .WithAutomaticReconnect()
      .Build();
});
#endregion

#region Services Injection
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IPosition, PositionService>();
builder.Services.AddScoped<IJobCategory, JobCategoryService>();
builder.Services.AddScoped<IRole, RoleService>();
builder.Services.AddScoped<IRateType, RateTypeService>();
builder.Services.AddScoped<IEmploymentStatus, EmploymentStatusService>();
builder.Services.AddScoped<ICourse, CourseService>();
builder.Services.AddScoped<ICompanyProfile, CompanyProfileService>();
builder.Services.AddScoped<IAddress, AddressService>();
builder.Services.AddScoped<ICscEligibility, CscEligibilityService>();
builder.Services.AddScoped<ITraining, TrainingService>();
builder.Services.AddScoped<ILevel, LevelService>();
builder.Services.AddScoped<IEmpRelatives, EmpRelativesServices>();
builder.Services.AddScoped<ILevelOrganization, LevelOrganizationService>();
builder.Services.AddScoped<IEduAttainment, ISEduAttainment>();
builder.Services.AddScoped<ISalaryGrade, SalaryGradeService>();
builder.Services.AddScoped<IPositionTraining, PositionTrainingService>();
builder.Services.AddScoped<ICharacterReference, CharacterReferenceService>();
builder.Services.AddScoped<IEmpEligibilities, ISEmpEligibilities>();
builder.Services.AddScoped<ITrainingSeminar, TrainingSeminarService>();
builder.Services.AddScoped<IEmpExperience, ISEmpExperience>();
builder.Services.AddScoped<IPlantilla, PlantillaService>();
builder.Services.AddScoped<IEmpComService, ISEmpCommunityService>();
builder.Services.AddScoped<ICredentials, ISEmployeeCredentials>();
builder.Services.AddScoped<IGeneralPolicy, GeneralPolicyService>();
builder.Services.AddScoped<IJobVacancies, JobVacancyService>();
builder.Services.AddScoped<IApplicants, ISApplicants>();
builder.Services.AddScoped<IPlacement, PlacementService>();
builder.Services.AddScoped<IHistoryEntry, HistoryEntryService>();
builder.Services.AddScoped<IEmpServiceRecords, ISEmpServiceRecords>();
builder.Services.AddScoped<IPersonalActionMemo, ISPersonalActionMemo>();
builder.Services.AddScoped<IServiceRecord, SRService>();
builder.Services.AddScoped<IPositionEligibility, PositionEligibilityService>();
builder.Services.AddScoped<IPositionExperience, PositionExperienceService>();
builder.Services.AddScoped<IPositionEducBackground, PositionEducBackgroundService>();
builder.Services.AddScoped<INonPlantilla, NonPlantillaService>();
builder.Services.AddScoped<IExam, ExamService>();
builder.Services.AddScoped<IProfileUpdate, ProfileUpdateService>();
builder.Services.AddScoped<IMail, MailService>();
builder.Services.AddScoped<IHeader, ISHeader>();
builder.Services.AddScoped<ICompetency, CompetencyService>();
builder.Services.AddScoped<ICompetencyLevelIndicator, CompetencyLevelIndicatorService>();
builder.Services.AddScoped<IDisability, DisabilityService>();
builder.Services.AddScoped<IEthnicity, EthnicityService>();
builder.Services.AddScoped<ILeaveType, LeaveTypeService>();
builder.Services.AddScoped<IPaperEvaluation, PaperEvaluationService>();
builder.Services.AddScoped<IApplicantEvaluation, ApplicantEvaluationService>();
builder.Services.AddScoped<IStaffing, StaffingService>();
builder.Services.AddScoped<IImportPDS, ImportPDSService>();
builder.Services.AddScoped<IPositionCompetency, PositionCompetencyService>();
builder.Services.AddScoped<IWorkplan, ISWorkplan>();
builder.Services.AddScoped<IBackgroundInvestigationQuestion, BackgroundInvestigationQuestionService>();
builder.Services.AddScoped<IOverallResult, OverallResultService>();
builder.Services.AddScoped<ILeavePermission, ISLeavePermission>();
builder.Services.AddScoped<ILeaveApplication, LeaveApplicationService>();
builder.Services.AddScoped<ILeaveType, LeaveTypeService>();
builder.Services.AddScoped<ILeaveTypeforModal, LeaveTypeforModalService>();
builder.Services.AddScoped<ITravelOrder, ISTravelOrder>();
builder.Services.AddScoped<IAuditTrail, ISAuditTrail>();
builder.Services.AddScoped<ILocatorSlip, LocatorSlipService>();
builder.Services.AddScoped<IReclassification, ReclassificationService>();
builder.Services.AddScoped<IHoliday, ISHoliDay>();
builder.Services.AddScoped<ISchedule, ScheduleService>();
builder.Services.AddScoped<IAllowancetype, AllowanceTypeService>();
builder.Services.AddScoped<ICountry, CountryService>();
builder.Services.AddScoped<IDeductionTypes, ISDeductionTypes>();
builder.Services.AddScoped<IReportSignatory, ReportSignatoryService>();
builder.Services.AddScoped<ILoanType, ISLoanType>();
builder.Services.AddScoped<IEmployeeAllowance, EmployeeAllowanceService>();
builder.Services.AddScoped<IHdmf, HdmfService>();
builder.Services.AddScoped<IPhilHealth, PhilHealthService>();
builder.Services.AddScoped<ISss, SssService>();
builder.Services.AddScoped<IEmployeePremium, EmployeePremiumService>();
builder.Services.AddScoped<IGsis, GsisService>();
builder.Services.AddScoped<IWTax, WTaxService>();
builder.Services.AddScoped<ILeavePolicy, LeavePolicyService>();
builder.Services.AddScoped<IPayrollDate, PayrollDateService>();
builder.Services.AddScoped<IEmployeeWithholdingTax, EmployeeWithholdingTaxService>();
builder.Services.AddScoped<INoticeOfStepIncrement, NoticeOfStepIncrementService>();
builder.Services.AddScoped<IRecruitmentPlan, RecruitmentPlanService>();
builder.Services.AddScoped<IApplicantCompetency, ApplicantCompetencyService>();
builder.Services.AddScoped<HRMSv4.Client.Interface.ISignal.IPermissionToLeave, HRMSv4.Client.Service.ISSignalR.ISPermissionToLeave>();
builder.Services.AddScoped<HRMSv4.Client.Interface.ISignal.ICompetencyAssessment, HRMSv4.Client.Service.ISSignalR.ISCompetencyAssessment>();
builder.Services.AddScoped<HRMSv4.Client.Interface.ISignal.ILocatorSlips, HRMSv4.Client.Service.ISSignalR.ISLocatorSlip>();
builder.Services.AddScoped<HRMSv4.Client.Interface.ISignal.ITravelOrder, HRMSv4.Client.Service.ISSignalR.ISTravelOrder>();
builder.Services.AddScoped<HRMSv4.Client.Interface.ISignal.ILeaveApplicationSignal, HRMSv4.Client.Service.ISSignalR.ISLeaveApplication>();
builder.Services.AddScoped<ILeaveCredit, ISLeaveCredit>();
builder.Services.AddScoped<ILeaveMonetization, ISLeaveMonetization>();
builder.Services.AddScoped<IMultiplier, MultiplierService>();
builder.Services.AddScoped<IPayroll, PayrollService>();
builder.Services.AddScoped<IEmployeeMasterList, ISEmployeeMasterList>();
builder.Services.AddScoped<IEmployeeLogs, ISEmployeeLogs>();
builder.Services.AddScoped<IEmployeeDeduction, EmployeeDeductionService>();
builder.Services.AddScoped<IPayrollClusters, PayrollClusterService>();
builder.Services.AddScoped<IPayrollProfile, PayrollProfileService>();
builder.Services.AddScoped<IEmployeeLoan, EmployeeLoanService>();
builder.Services.AddScoped<HRMSv4.Client.Interface.Assessment.IAssessment, ISAssessment>();
builder.Services.AddScoped<IApprovedLog, ISApprovedLog>();
builder.Services.AddScoped<IPayrollSetting, PayrollSettingService>();
builder.Services.AddScoped<ILeaveDashboard, LeaveDashboardService>();
builder.Services.AddScoped<IEmpScheduleLog, ISEmpScheduleLog>();
builder.Services.AddScoped<IEmpLoan, ISEmpLoan>();
builder.Services.AddScoped<IEmpAllowance, ISEmpAllowance>();
builder.Services.AddScoped<IEmpPremium, ISEmpPremium>();
builder.Services.AddScoped<IDumpPayroll, DumpPayrollService>();
builder.Services.AddScoped<IWeeklySchedules, WeeklyScheduleService>();
//builder.Services.AddSubtleCrypto(opt =>
//    opt.Key = "UKF1H8Hno9MImwjCUr2ZA2fmTCeNFl"       
//);
builder.Services.AddScoped<ISignalR, SignalRService>();
builder.Services.AddScoped<IStations, ISstations>();
builder.Services.AddScoped<IDevices, ISDevices>();
#endregion

#region Services Extension
//builder.Services.AddOptions();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddHttpClientInterceptor();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSweetAlert2();

/* For Encryption/Decryption */
builder.Services.AddScoped<IEncryption, ISEncryption>();
builder.Services.AddTransient<GooglereCaptchaService>();
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<Radzen.ContextMenuService>();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
builder.Services.AddJsInteropExtensions();
#endregion

#region Other Services
/* Global Variable */
builder.Services.AddSingleton<InfoGlobalClass>();
builder.Services.AddScoped<SpinnerService>();
#endregion

//builder.Services.AddScoped<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
//builder.Services.AddScoped(s =>
//{
//    var accessTokenHandler = s.GetRequiredService<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
//    accessTokenHandler.InnerHandler = new HttpClientHandler();
//    var uriHelper = s.GetRequiredService<NavigationManager>();
//    return new HttpClient(accessTokenHandler)
//    {
//        BaseAddress = new Uri(uriHelper.BaseUri)
//    };
//});


await builder.Build().RunAsync();
