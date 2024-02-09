using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface IHistoryEntry
    {
        Task<HistoryEntry> GetHistoryEntry(int id);
        Task<IEnumerable<HistoryEntryViewModel>> GetHistoryEntries(int positionItemId);
    }
}
