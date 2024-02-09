using HRMSv4.Client.Interface;
using HRMSv4.Shared.Notification;
using System.Net.Http.Json;
using System.Text.Json;

namespace HRMSv4.Client.Service
{
    public class ISHeader : IHeader
    {
        private readonly HttpClient _httpClient;

        public ISHeader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NotificationView> NotificationList(int employeeId)
        {
            try
            {
                //var result = await _httpClient.GetFromJsonAsync<List<NoticeHistoryLog>>($"api/Header/NotificationList?employeeId={employeeId}");
                var result = await _httpClient.GetFromJsonAsync<NotificationView>("Header/NotificationList?employeeId=" + employeeId);
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

        public async Task<int> GetNotificationCount()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<int>("Header/NotificationList");
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<int> GetEmployeeId(string userId)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<int>($"Header/GetEmployeeId?userId={userId}");
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


    }
}
