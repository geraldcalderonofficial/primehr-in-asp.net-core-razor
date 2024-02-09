using HRMSv4.Client.Interface;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public abstract class ISRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly HttpClient _httpClient;
        public ISRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        //public async Task<HttpResponseMessage> Delete(int id, string controller)
        //{
        //    var result = await _httpClient.DeleteAsync($"/api/{controller}/{id}");
        //    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        //    return result.EnsureSuccessStatusCode();
        //}

        //public IQueryable<TEntity> FindAll(string controller)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<TEntity> Get(int id, string controller)
        //{
        //    var result = await _httpClient.GetFromJsonAsync<TEntity>($"/api/{controller}/{id}");
        //    return result;
        //}

        //public async Task<List<TEntity>> GetAll(string controller)
        //{
        //    var result = await _httpClient.GetFromJsonAsync<List<TEntity>>($"/api/{controller}");
        //    return result;
        //}

        //public async Task<HttpResponseMessage> Insert(TEntity entity, string controller)
        //{
        //    var result = await _httpClient.PostAsJsonAsync($"/api/{controller}", entity);
        //    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        //    return result.EnsureSuccessStatusCode();
        //}

        //public async Task<HttpResponseMessage> Update(TEntity entity, string controller)
        //{
        //    var result = await _httpClient.PutAsJsonAsync($"/api/{controller}/", entity);
        //    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        //    return result.EnsureSuccessStatusCode();
        //}
    }
}
