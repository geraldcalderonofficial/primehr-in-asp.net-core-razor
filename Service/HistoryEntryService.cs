using System.Net.Http.Json;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;

namespace HRMSv4.Client.Service
{
    public class HistoryEntryService : IHistoryEntry
    {
        private readonly HttpClient _httpClient;

        public HistoryEntryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HistoryEntry> GetHistoryEntry(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<HistoryEntry>($"HistoryEntry/{id}");
            return result;
        }
        public async Task<IEnumerable<HistoryEntryViewModel>> GetHistoryEntries(int positionItemId)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<HistoryEntryViewModel>>($"HistoryEntry/HistoryEntries?positionItemId={positionItemId}");
            return result;
        }

    }
}
