using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.DbViews;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;

namespace HRMSv4.Client.Service
{
    public class NonPlantillaService : INonPlantilla
    {
        private readonly HttpClient _httpClient;
        public NonPlantillaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<NonPlantillaRecordView>> GetNonPlantillaList(string sortBy, string arrangeBy, string orgId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<NonPlantillaRecordView>>($"NonPlantilla/List?sortBy={sortBy}&arrangeBy={arrangeBy}&orgId={orgId}");
            return result;
        }

        public async Task<PositionItemView> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionItemView>($"NonPlantilla/{id}");
            return result;
        }

        public async Task<Response> Add(PositionItemView positionItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<PositionItemView>($"NonPlantilla", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> Update(PositionItemView positionItem)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<PositionItemView>($"NonPlantilla", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Position>> GetOpenList()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Position>>($"NonPlantilla/NonPlantillaPositions");
            return result;
        }

        public async Task<Response> AbolishItem(int id, string userId)
        {
            try
            {
                //var result = await _httpClient.PostAsJsonAsync($"/api/NonPlantilla/Abolish?id=", id);
                //string res = await result.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<Response>(res);
                var result = await _httpClient.GetFromJsonAsync<Response>($"NonPlantilla/Abolish?id={id}&userId={userId}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
