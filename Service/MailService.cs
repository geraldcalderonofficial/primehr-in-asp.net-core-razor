using HRMSv4.Client.Interface;
using HRMSv4.Shared.Mailing;
using System.Net.Http.Json;
using System.Text.Json;

namespace HRMSv4.Client.Service
{
    public class MailService : IMail
    {
        private readonly HttpClient _httpClient;
        public MailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Add(Mail mail)
        {
            var result = await _httpClient.PostAsJsonAsync($"Mail", mail);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<Mail> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Mail>($"Mail/{id}");
            return result;
        }

        public async Task<MailListView> GetAll(string id, int currentPage, string? search)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<MailListView>("Mail/All?id=" + id + "&currentPage=" + currentPage + "&search=" + search);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }

        public async Task<MailCount> GetMailCount(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<MailCount>($"Mail/Count?id=" + id);
            return result;
        }

        public async Task<IEnumerable<MailEmployeeList>> GetEmployees(int loggedIn)
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<MailEmployeeList>>("Mail/GetEmployee?loggedIn=" + loggedIn);
            return result;
        }

        public async Task<MailListView> GetSent(string id, int currentPage, string? search)
        {
            var result = await _httpClient.GetFromJsonAsync<MailListView>("Mail/GetSent?id=" + id + "&currentPage=" + currentPage + "&search=" + search);
            return result;
        }

        public async Task<MailListView> GetTrash(string id, int currentPage, string? search)
        {
            var result = await _httpClient.GetFromJsonAsync<MailListView>("Mail/GetTrash?id=" + id + "&currentPage=" + currentPage + "&search=" + search);
            return result;
        }

        public async Task<HttpResponseMessage> Trash(string ids)
        {
            var result = await _httpClient.DeleteAsync($"Mail/TrashMail?ids=" + ids);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> Favorite(int id, bool isFavorite)
        {
            var result = await _httpClient.DeleteAsync($"Mail/FavoriteMail?id=" + id + "&isFavorite=" + isFavorite);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> ReadMail(int id)
        {
            var result = await _httpClient.DeleteAsync($"Mail/ReadMail?id=" + id);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }

        public async Task<HttpResponseMessage> DeleteTrash(string ids)
        {
            var result = await _httpClient.DeleteAsync($"Mail/DeleteTrash?ids=" + ids);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
    }
}
