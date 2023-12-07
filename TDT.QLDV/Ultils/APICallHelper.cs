using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TDT.QLDV.Models;

namespace TDT.QLDV.Ultils
{
    public static class APICallHelper
    {
        private static readonly string VERSION = "1.0";
        private static readonly string DOMAIN = $@"https://localhost:44300/api/v{VERSION}/";
        //private static readonly string DOMAIN = $@"https://tdt-api.somee.com/api/v{VERSION}/";
        private static HttpClient HTTP_CLIENT;

        public static async Task<T> Get<T>(string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            return await ExecuteRequest<T>(HttpMethod.Get, url, requestBody, token);
        }
        public static async Task<T> Post<T>(string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            return await ExecuteRequest<T>(HttpMethod.Post, url, requestBody, token);
        }
        public static async Task<T> Put<T>(string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            return await ExecuteRequest<T>(HttpMethod.Put, url, requestBody, token);
        }
        public static async Task<T> Delete<T>(string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            return await ExecuteRequest<T>(HttpMethod.Delete, url, requestBody, token);
        }
        public static async Task<T> ExecuteRequest<T>(HttpMethod method, string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            HTTP_CLIENT = new HttpClient();
            HTTP_CLIENT.CancelPendingRequests();
            HTTP_CLIENT.BaseAddress = new Uri(DOMAIN);
            HTTP_CLIENT.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string requestUri = DOMAIN + url;
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(requestUri),
            };
            HttpResponseMessage response;
            if (!string.IsNullOrEmpty(token))
            {
                HTTP_CLIENT.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            }
            if (!string.IsNullOrEmpty(requestBody))
            {                
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                response = HTTP_CLIENT.SendAsync(request).Result;
            }
            else
            {
                response = HTTP_CLIENT.GetAsync(requestUri).Result;
            }

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                case System.Net.HttpStatusCode.MethodNotAllowed:
                case System.Net.HttpStatusCode.Forbidden:
                case System.Net.HttpStatusCode.BadRequest:
                    return JsonConvert.DeserializeObject<T>(
                                                APIHelper.GetJsonString(APIStatusCode.AccessDenied)
                                            );
                case System.Net.HttpStatusCode.NotFound:
                case System.Net.HttpStatusCode.Gone:
                    return JsonConvert.DeserializeObject<T>(
                                                APIHelper.GetJsonString(APIStatusCode.NotFound)
                                            );
            }
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
