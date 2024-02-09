using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ISalaryGrade
    {
        //effectivity date
        Task<List<SalaryGradeEffectivityDateView>> GetEffectivityDates(bool isPlantilla);
        Task<SalaryGradeEffectivityDateView> GetEffectivityDate(string dateString, string annex, string isPlantilla);
        Task<SalaryGrade> GetSalaryGrade(string dateString, string annex, int sgNo, bool isPlantilla);
        Task<Response> AddEffectivityDate(SalaryGradeEffectivityDateView effectivityDate);
        Task<Response> UpdateEffectivityDate(SalaryGradeEffectivityDateView effectivityDate);
        Task<Response> DeleteEffectivityDate(string dateString, string annex, bool isPlantilla);

        //salary grade
        Task<IEnumerable<SalaryGrade>> GetSalaryGrades(string dateString, string annex, bool isPlantilla);
        Task<Response> AddSalaryGrade(SalaryGrade salaryGrade);
        Task<Response> UpdateSalaryGrade(SalaryGrade salaryGrade);
        Task<Response> DeleteSalaryGrade(int id);
        Task<List<string>> SalaryGradeAnnexAll();
        Task<List<int>> SalaryGradeNumberAll(string annex);
        Task<IEnumerable<SalaryGrade>> GetSalaryGradeList(string? dateString, string? annex, bool? isPlantilla);
    }
}
