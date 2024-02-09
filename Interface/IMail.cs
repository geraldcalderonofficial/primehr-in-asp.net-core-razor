using HRMSv4.Shared.Mailing;

namespace HRMSv4.Client.Interface
{
    public interface IMail
    {
        Task<MailListView> GetAll(string id, int currentPage, string? search);
        Task<MailListView> GetSent(string id, int currentPage, string? search);
        Task<MailListView> GetTrash(string id, int currentPage, string? search);
        Task<Mail> Get(int id);
        Task<MailCount> GetMailCount(string id);
        Task<HttpResponseMessage> Add(Mail mail);
        Task<IEnumerable<MailEmployeeList>> GetEmployees(int loggedIn);
        Task<HttpResponseMessage> Trash(string ids);
        Task<HttpResponseMessage> Favorite(int id, bool isFavorite);
        Task<HttpResponseMessage> ReadMail(int id);
        Task<HttpResponseMessage> DeleteTrash(string ids);      
    }
}
