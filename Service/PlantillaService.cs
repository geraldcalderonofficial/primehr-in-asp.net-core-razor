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
    public class PlantillaService : IPlantilla
    {
        private readonly HttpClient _httpClient;

        public PlantillaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PositionItem>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionItem>>("Plantilla");
            return result;
        }

        public async Task<Response> Add(PositionItemView positionItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<PositionItemView>($"Plantilla", positionItem);
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
                var result = await _httpClient.PutAsJsonAsync<PositionItemView>($"Plantilla", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlantillaRecordView>> GetPlantillaList(string sortBy, string arrangeBy, string orgId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PlantillaRecordView>>($"Plantilla/List?sortBy={sortBy}&arrangeBy={arrangeBy}&orgId={orgId}");
            return result;
        }

        public async Task<Response> CheckPlantilla()
        {
            var result = await _httpClient.GetFromJsonAsync<Response>("Plantilla/CheckPlantilla");
            return result;
        }

        public async Task<Response> PlantillaYear(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>("Plantilla/PlantillaYear?id=" + id);
            return result;
        }

        public async Task<PositionItemView> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionItemView>($"Plantilla/{id}");
            return result;
        }

        public async Task<Response> GetCheckSelectedPlantilla(int positionItemId)
        {
            var result = await _httpClient.GetFromJsonAsync<Response>("Plantilla/CheckCurrentPlantilla?positionItemId=" + positionItemId);
            return result;
        }

        public async Task<Response> AbolishItem(PositionItem positionItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<PositionItem>($"Plantilla/Abolish", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PositionItemList>> GetOpenPositionItem(int organizationId, int positionId, bool isPlantilla)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<PositionItemList>>($"Plantilla/GetPositionItem?organizationId={organizationId}&positionId={positionId}&isPlantilla={isPlantilla}");
            return result;
        }

        public async Task<Response> PassList(List<PlantillaRecordView> positionItem, int id)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Plantilla/PassList?id=" + id, positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> TempPlantilla(PlantillaRecordView positionItem)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Plantilla/TempPlantilla", positionItem);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlantillaSearchView>> SearchPlantilla(int salaryGrade, int taskRequest)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<PlantillaSearchView>>($"Plantilla/Search?salaryGrade={salaryGrade}&taskRequest={taskRequest}");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Position>> GetOpenList()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Position>>($"Plantilla/PlantillaPositions");
            return result;
        }
    }
}
