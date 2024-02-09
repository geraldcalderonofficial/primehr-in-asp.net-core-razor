using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using HRMSv4.Shared.SignalRData;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Reactive;

namespace HRMSv4.Client.Service
{
    public class SignalRService : ISignalR
    {
        private readonly HttpClient _httpClient;

        public SignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> RefreshResult()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Response>("Signal");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }      
        }

        public async Task<Response> ProfileUpdateRequest(NotificationRequest notification)
        {
            var result = await _httpClient.PostAsJsonAsync("Signal/AddNotification", notification);
            
            if (result.IsSuccessStatusCode)
            {
                return new Response
                {
                    StatusCode = 200,
                    Value = "A request was successfully send."
                };
            } else
            {
                return new Response
                {
                    StatusCode = 500,
                    Value = "Invalid request."
                };
            }
        }

        public async Task<List<AdminViews>> Receivers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AdminViews>>("Signal/Receivers");
            return result;    
        }

        public async Task<int> NotificationCounter(bool isRead, int employeeId, string? userId)
        {
            try
            {
                //$"/api/Plantilla/List?sortBy={sortBy}&arrangeBy={arrangeBy}&orgId={orgId}"
                var result = await _httpClient.GetFromJsonAsync<int>($"Mail/GetGlobalNotificationCounter?isRead={isRead}&employeeId={employeeId}&userId={userId}");
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<int> UpdateNotification(HRMSv4.Shared.Notification.NotificationCounterView counterView)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"Mail/UpdateNotification", counterView);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(res);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
