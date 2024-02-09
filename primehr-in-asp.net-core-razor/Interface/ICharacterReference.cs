using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;

namespace HRMSv4.Client.Interface
{
    public interface ICharacterReference
    {
        Task<IEnumerable<CharacterReferenceListView>> GetAll(int id);
        Task<CharacterReference> Get(int id);
        Task<HttpResponseMessage> Add(CharacterReference cr);
        Task<HttpResponseMessage> Update(CharacterReference cr);
        Task<HttpResponseMessage> Delete(int id);
        Task<CharacterReferenceInfo> CharReference(int id, int refId);
        Task<Response> SendCharacterInfo(int id);
    }
}