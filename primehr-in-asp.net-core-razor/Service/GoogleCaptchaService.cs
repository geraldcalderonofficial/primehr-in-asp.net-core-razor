using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Net.Http.Json;
using System.Threading.Tasks;


namespace reCAPTCHADemo.Services
{
    public class GooglereCaptchaService
    {
        HttpClient httpClient = new HttpClient();
        public GooglereCaptchaService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        private ReCaptchaSettings _settings = new ReCaptchaSettings();

        public virtual async Task<GoogleREspo> reVerify(string _Token)
        {
            try
            {
                GooglereCaptchaData _MyData = new GooglereCaptchaData { response = _settings.siteKey, secret = _settings.secretKey };

                GoogleREspo _GoogleREspo = new GoogleREspo();
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("secret", _settings.secretKey), new KeyValuePair<string, string>("response", _settings.siteKey) });
                var response = await httpClient.PostAsync($"https://www.google.com/recaptcha/api/siteverify", content);

                var jsonString = await response.Content.ReadAsStringAsync();
                var capresponse = JsonConvert.DeserializeObject<GoogleREspo>(jsonString);
                return capresponse;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    public class GooglereCaptchaData
    {
        public string response { get; set; } //tocken
        public string secret { get; set; }
    }

    public class GoogleREspo
    {
        public bool success { get; set; }
        public double score { get; set; }
        public string action { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
    }

    public class ReCaptchaSettings
    {
        public string siteKey { get; set; } = "6Lf_oCkfAAAAAF_KdNly6cP6uZA1oCMj9o7J1VE8";
        public string secretKey { get; set; } = "6Lf_oCkfAAAAAJICwhvQ5hCfmq2MR_Fs81T76g3w";

    }
}