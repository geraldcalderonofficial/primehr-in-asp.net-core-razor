using HRMSv4.Shared;
using HRMSv4.Shared.SignalRData;

namespace HRMSv4.Client.Interface
{
    public interface ISignalR
    {
        Task<Response> ProfileUpdateRequest(NotificationRequest notification);
        Task<List<AdminViews>> Receivers();
        Task<Response> RefreshResult();
        Task<int> NotificationCounter(bool isRead, int employeeId, string? userId);
        Task<int> UpdateNotification(HRMSv4.Shared.Notification.NotificationCounterView counterView);
    }
}
