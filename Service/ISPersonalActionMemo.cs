using HRMSv4.Client.Interface;
using HRMSv4.Client.Pages.Masterdata;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Web.Mvc;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace HRMSv4.Client.Service
{
    public class ISPersonalActionMemo : IPersonalActionMemo
    {
        private readonly HttpClient _httpClient;
        public ISPersonalActionMemo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<HttpResponseMessage> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonnelActionMemo>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonnelActionMemo> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PersonnelActionMemo>($"PersonalActionMemo/GetById?id=" + id);
            return result;
        }

        public async Task<List<SelectListItems>> GetEmploymentStatus()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SelectListItems>>("PersonalActionMemo/EmploytmentStatus");
            return result;
        }

        //public async Task<HttpResponseMessage> Insert(PersonnelActionMemo entity)
        //{
        
        //}

        public Task<HttpResponseMessage> Update(PersonnelActionMemo entity)
        {
            throw new NotImplementedException();
        }
        public async Task<Response> GetRenewal(PersonnelActionMemo memo)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"PersonalActionMemo/RequestRenewal", memo);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> GetReElection(PersonnelActionMemo memo)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync($"PersonalActionMemo/RequestReElection", memo);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> AddEmployeeSeparation(PersonnelActionMemo memo)
        {
            var result = await _httpClient.PostAsJsonAsync("PersonalActionMemo/EmpSeparation", memo);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
            //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            //return result.EnsureSuccessStatusCode();
        }
        public async Task<Response> GetSeparationType(int pamId)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>("PersonalActionMemo/SeparationType?pamId=" + pamId);
            return result;
        }

        public async Task<Response> GetPersonnelStatus(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>("PersonalActionMemo/PersonnelStatus?id=" + id);
            return result;
        }

        public async Task<IEnumerable<SalAdjDatesAnnex>> GetSalAdjDateEffectivity()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<SalAdjDatesAnnex>>("PersonalActionMemo/GetSalAdjDateEffectivity");
            return result;
        }

        public async Task<GetSalaryRateListView> GetSalaryRate(int sgId, string salaryGradeNumber, int serviceRecordId)
        {
            var result = await _httpClient.GetFromJsonAsync<GetSalaryRateListView>("PersonalActionMemo/GetSalaryRate?sgId=" + sgId + "&salaryGradeNumber=" + salaryGradeNumber + "&serviceRecordId=" + serviceRecordId );
            return result;
        }

        public async Task<IEnumerable<PamTurnAroundTimeView>> GetApplicants(int posId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PamTurnAroundTimeView>>($"PersonalActionMemo/GetApplicants?posId=" + posId); 
            return result;
        }

        public async Task<Response> Put(PersonnelActionMemo memo)
        {
            var result = await _httpClient.PutAsJsonAsync<PersonnelActionMemo>("PersonalActionMemo", memo);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        Task<HttpResponseMessage> IGenericRepository<PersonnelActionMemo>.Insert(PersonnelActionMemo entity)
        {
            throw new NotImplementedException();
        }

        Task<Response> Insert(PersonnelActionMemo entity)
        {
            throw new NotImplementedException();
        }

        async Task<Response> IPersonalActionMemo.New(PersonnelActionMemo entity)
        {
            var result = await _httpClient.PostAsJsonAsync("PersonalActionMemo", entity);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
