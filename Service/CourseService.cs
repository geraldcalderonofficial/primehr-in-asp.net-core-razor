using HRMSv4.Client.Interface;
using HRMSv4.Shared;
using HRMSv4.Shared.OnBoarding;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HRMSv4.Client.Service
{
    public class CourseService: ICourse
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> Add(Course course)
        {
            var result = await _httpClient.PostAsJsonAsync("Course", course);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"Course/{id}");
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }

        public async Task<Course> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Course>($"Course/{id}");
            return result;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Course>>("Course");
            return result;
        }

        public async Task<IEnumerable<Course>> GetBachelors()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Course>>("Course/Bachelors");
            return result;
        }

        public async Task<Response> GetCheckDuplicate(Course course)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<Course>($"Course/CheckDuplicate", course);

                string res = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(res);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Course>> GetDoctorate()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Course>>("Course/Doctorate");
            return result;
        }

        public async Task<IEnumerable<Course>> GetMasters()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Course>>("Course/Masters");
            return result;
        }

        public async Task<IEnumerable<Course>> GetVocational()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Course>>("Course/Vocational");
            return result;
        }

        public async Task<Response> Update(Course course)
        {
            var result = await _httpClient.PutAsJsonAsync<Course>($"Course", course);
            string res = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response>(res);
        }
    }
}
