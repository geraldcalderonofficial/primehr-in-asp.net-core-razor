using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.Selection;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CharacterReferenceService : ICharacterReference
    {
        private readonly HttpClient _httpClient;
        public CharacterReferenceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Add(CharacterReference cr)
        {
            var result = await _httpClient.PostAsJsonAsync($"CharacterReference", cr);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<CharacterReferenceInfo> CharReference(int id, int refId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<CharacterReferenceInfo>($"characterReference/referenceinfo/?id={id}&refId={refId}");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"CharacterReference/{id}");
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<CharacterReference> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CharacterReference>($"CharacterReference/{id}");
            return result;
        }

        public async Task<IEnumerable<CharacterReferenceListView>> GetAll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CharacterReferenceListView>>("CharacterReference/All?id=" + id);
            return result;
        }

        public async Task<Response> SendCharacterInfo(int id)
        {
            try
            {
                Response result = await _httpClient.GetFromJsonAsync<Response>("CharacterReference/SendMailInvitation/?id=" + id);
                //string res = await result.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<Response>(res);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> Update(CharacterReference cr)
        {
            var result = await _httpClient.PutAsJsonAsync<CharacterReference>("CharacterReference/", cr);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
    }
}
