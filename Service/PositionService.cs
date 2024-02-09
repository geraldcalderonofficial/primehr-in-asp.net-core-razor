using System.Net.Http.Json;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;

namespace HRMSv4.Client.Service
{
    public class PositionService : IPosition
    {
        private readonly HttpClient _httpClient;

        public PositionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(PositionListViewModel category)
        {
            var result = await _httpClient.PostAsJsonAsync("Position", category);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Position/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<PositionListViewModel> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionListViewModel>($"Position/{id}");
            return result;
        }

        public async Task<IEnumerable<PositionListViewModel>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionListViewModel>>("Position");
            return result;
        }

        public async Task<Response> PositionQualifications(PositionQualificationList position)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Position/PositionQualifications", position);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Update(PositionListViewModel category)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<PositionListViewModel>($"Position", category);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<PositionListViewModel>> GetPositionsWithSg(bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionListViewModel>>($"Position/PositionsWithSg?isPlantilla={isPlantilla}");
            return result;
        }

        //Task IPosition.Update(Position category)
        //{
        //    throw new NotImplementedException();
        //}

        //void IJobCategory.Update(JobCategory entity)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<IEnumerable<PositionListViewModel>> GetEmpPosition(string name)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionListViewModel>>("Position/GetEmpPosition?name=" + name);
            return result;
        }

        public async Task<Position> GetPositionById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Position>("Position/GetPositionById?id="+id);
            return result;
        }
    }
}
