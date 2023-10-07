﻿
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.Models;

namespace TDT.Core.Ultils
{
    public static class APICallHelper
    {
        private static readonly string VERSION = "1.0";
        private static readonly string DOMAIN = @$"https://localhost:44300/api/v{VERSION}/";
        private static HttpClient HTTP_CLIENT;

        public static async Task<T> Get<T>(string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            return await ExecuteRequest<T>(HttpMethod.Get, url, requestBody, token);
        }
        public static async Task<T> Post<T>(string url = "", string requestBody = null, string token = null) where T : APIResponseModel
        {
            return await ExecuteRequest<T>(HttpMethod.Post, url, requestBody, token);
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
                response = HTTP_CLIENT.Send(request);
            }
            else
            {
                response = HTTP_CLIENT.GetAsync(requestUri).Result;
            }

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                case System.Net.HttpStatusCode.MethodNotAllowed:
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(
                                                APIHelper.GetJsonResult(APIStatusCode.AccessDenied).Value
                                            ));
                case System.Net.HttpStatusCode.NotFound:
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(
                                                APIHelper.GetJsonResult(APIStatusCode.NotFound).Value
                                            ));
            }
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
