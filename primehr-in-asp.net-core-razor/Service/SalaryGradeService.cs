using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class SalaryGradeService : ISalaryGrade
    {
        private readonly HttpClient _httpClient;
        public SalaryGradeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //effectivity dates
        public async Task<List<SalaryGradeEffectivityDateView>> GetEffectivityDates(bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<List<SalaryGradeEffectivityDateView>>($"SalaryGrade/EffectivityDates/{isPlantilla}");
            return result;
        }

        public async Task<SalaryGradeEffectivityDateView> GetEffectivityDate(string dateString, string annex, string isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<SalaryGradeEffectivityDateView>("SalaryGrade/EffectivityDateEntry?dateString=" + dateString + "&annex=" + annex + "&isPlantilla=" + isPlantilla);
            return result;
        }

        public async Task<Response> AddEffectivityDate(SalaryGradeEffectivityDateView effectivityDate)
        {
            var result = await _httpClient.PostAsJsonAsync("SalaryGrade/EffectivityDate", effectivityDate);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> UpdateEffectivityDate(SalaryGradeEffectivityDateView effectivityDate)
        {
            var result = await _httpClient.PutAsJsonAsync($"SalaryGrade/EffectivityDate", effectivityDate);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteEffectivityDate(string dateString, string annex, bool isPlantilla)
        {
            var result = await _httpClient.DeleteAsync($"SalaryGrade/EffectivityDate/{dateString}/{annex}/{isPlantilla}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        //salary grades
        public async Task<IEnumerable<SalaryGrade>> GetSalaryGrades(string dateString, string annex, bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<SalaryGrade>>($"SalaryGrade/SalaryGrades/{dateString}/{annex}/{isPlantilla}");
            return result;
        }

        public async Task<Response> AddSalaryGrade(SalaryGrade salaryGrade)
        {
            var result = await _httpClient.PostAsJsonAsync<SalaryGrade>("SalaryGrade/SalaryGrade", salaryGrade);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> UpdateSalaryGrade(SalaryGrade salaryGrade)
        {
            var result = await _httpClient.PutAsJsonAsync<SalaryGrade>($"SalaryGrade/SalaryGrade", salaryGrade);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> DeleteSalaryGrade(int id)
        {
            var result = await _httpClient.DeleteAsync($"SalaryGrade/SalaryGrade/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<SalaryGrade> GetSalaryGrade(string dateString, string annex, int sgNo, bool isPlantilla)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<SalaryGrade>("SalaryGrade/SalaryGradeEntry?dateString=" + dateString + "&annex=" + annex + "&sgNo=" + sgNo + "&isPlantilla=" + isPlantilla);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<List<string>> SalaryGradeAnnexAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<string>>($"SalaryGrade/SalaryGradeAnnexAll");
            return result;
        }

        public async Task<List<int>> SalaryGradeNumberAll(string annex)
        {
            var result = await _httpClient.GetFromJsonAsync<List<int>>($"SalaryGrade/SalaryGradeNumberAll?annex=" + annex);
            return result;
        }

        public async Task<IEnumerable<SalaryGrade>> GetSalaryGradeList(string? dateString, string? annex, bool? isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<SalaryGrade>>($"SalaryGrade/List?dateString={dateString}&annex={annex}&isPlantilla={isPlantilla}");
            return result;
        }
    }
}
