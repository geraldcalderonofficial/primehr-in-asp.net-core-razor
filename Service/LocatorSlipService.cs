using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.HrMgmt;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Web.Mvc;
using DevExpress.DataAccess.Native.Web;

namespace HRMSv4.Client.Service
{
    public class LocatorSlipService : ILocatorSlip
    {
        readonly HttpClient _httpClient;
        public LocatorSlipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> AddLocatorSlip(LocatorSlip locatorSlip)
        {
            try
            {
                Response isResponse = new Response();

                var result = await _httpClient.PostAsJsonAsync("LocatorSlips/AddLocatorSlip", locatorSlip);

                if (locatorSlip.LocatorSlipId > 0)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        isResponse = new Response
                        {
                            StatusCode = 200,
                            Value = "A new record was successfully Updated."
                        };
                    }
                    else
                    {
                        isResponse = new Response
                        {
                            StatusCode = 404,
                            Value = "Please complete all information!"
                        };
                    }
                }
                else
                {
                    if (result.IsSuccessStatusCode)
                    {
                        isResponse = new Response
                        {
                            StatusCode = 200,
                            Value = "A new record was successfully added."
                        };
                    }
                    else
                    {
                        isResponse = new Response
                        {
                            StatusCode = 404,
                            Value = "Please complete all information!"
                        };
                    }
                }

                return isResponse;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<LocatorSlipView>> GetLocatorSlip(string status, DateTime? Start, DateTime? End, int Id)
        {
            try
            {
                string startDate = Start == null || Start.HasValue == null ? ("1900-01-01") : Start.Value.ToString("yyyy-MM-dd");
                string endDate = End == null || End.HasValue == null ? ("1900-01-01") : End.Value.ToString("yyyy-MM-dd");

                var result = await _httpClient.GetFromJsonAsync<List<LocatorSlipView>>("LocatorSlips/LocatorSlipList?status="+ status + "&start=" + startDate + "&end=" + endDate + "&Id=" + Id);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response> DeleteLocatorSlip(int id)
        {
            try
            {
                Response res = new Response();
                var result = await _httpClient.DeleteAsync("LocatorSlips/DeleteLocatorSlip?id=" + id);
                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Record Deleted"
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong"
                    };
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LocatorSlip>> GetLocatorSlipDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetUserData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateLocatorSlip(LocatorSlip locatorSlip)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> accept(LocatorSlipView locatorSlip)
        {
            try
            {
                Response res = new Response();

                var result = await _httpClient.PutAsJsonAsync("LocatorSlips/Approval", locatorSlip);

                if (result.IsSuccessStatusCode)
                {
                    res = new Response
                    {
                        StatusCode = 200,
                        Value = "Request Updated"
                    };
                }
                else
                {
                    res = new Response
                    {
                        StatusCode = 500,
                        Value = "Something went wrong"
                    };
                }
                return res;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> ValidateLocatorSlipNo(int empId, DateTime? dtFrom, DateTime? to, string type)
        {
            try
            {
                string startDate = dtFrom == null || dtFrom.HasValue == null ? ("1900-01-01") : dtFrom.Value.ToString("yyyy-MM-dd");
                string endDate = to == null || to.HasValue == null ? ("1900-01-01") : to.Value.ToString("yyyy-MM-dd");

                var result = await _httpClient.GetFromJsonAsync<bool>("LocatorSlips/validatelocatorslip?empId=" + empId + "&startDate=" + startDate + "&endDate=" + endDate + "&type=" + type);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
