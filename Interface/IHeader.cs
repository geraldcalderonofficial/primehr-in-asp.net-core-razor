namespace HRMSv4.Client.Interface
{
    public interface IHeader
    {
        Task<HRMSv4.Shared.Notification.NotificationView> NotificationList(int employeeId);
        Task<int> GetNotificationCount();
        Task<int> GetEmployeeId(string userId);

    }
}
