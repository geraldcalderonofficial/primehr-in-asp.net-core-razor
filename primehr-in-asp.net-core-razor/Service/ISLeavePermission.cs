using DevExpress.DataAccess.Native.Web;
using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class ISLeavePermission : ILeavePermission
    {
        private readonly HttpClient _httpClient;
        public ISLeavePermission(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IQueryable<LeavePermissionView>> All(string status, DateTime? Start, DateTime? End, int Id)
        {
            try
            {
                string dateStart = Start == null || Start.HasValue == null ? ("1900-01-01") : Start.Value.ToString("yyyy-MM-dd");
                string dateEnd = End == null || End.HasValue == null ? ("1900-01-01") : End.Value.ToString("yyyy-MM-dd");  

                var result = await _httpClient.GetFromJsonAsync<List<LeavePermissionView>>("LeavePermission/All?status="+status + "&start=" + dateStart + "&end=" + dateEnd + "&Id=" +Id);

                var queryableList = result.AsQueryable();

                return queryableList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Response> Insert(LeavePermissionView _leave)
        {
            try
            {

                var result = await _httpClient.PostAsJsonAsync<LeavePermissionView>("LeavePermission/PostLeavePermission", _leave);
                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<LeavePermissionView> Find(int id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<LeavePermissionView>($"LeavePermission/Find?id=" + id);
                return res;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                Response res = new Response();
                var result = await _httpClient.DeleteAsync("LeavePermission/Delete?id=" + id);
                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Record Deleted."
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong."
                    };
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<Response> Update(LeavePermissionView item)
        {
            throw new NotImplementedException();
        }

        Task<Response> ILeavePermission.Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Save(LeavePermissionView item)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Patch(LeavePermissionView _leave)
        {

            try
            {
                Response res = new Response();

                var result = await _httpClient.PutAsJsonAsync("LeavePermission/Approval", _leave);

                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Request Updated."
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong."
                    };
                }
                return res;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
