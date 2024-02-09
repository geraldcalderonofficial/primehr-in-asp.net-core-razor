using System.Linq.Expressions;

namespace HRMSv4.Client.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int id);
        Task<T> GetById(int id);
        Task<HttpResponseMessage> Insert(T entity);
        Task<HttpResponseMessage> Update(T entity);
        Task<HttpResponseMessage> Delete(int id);
    }
}
