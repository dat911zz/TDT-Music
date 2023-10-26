using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Extensions;
using Newtonsoft.Json;
using TDT.Core.Helper;
using System.Collections;

namespace TDT.Core.Ultils
{
    public static class APIHelper
    {
        public static JsonResult GetJsonResult(Enum value, Dictionary<string, object> data = null, string formatValue = "")
        {
            var jsonData = new Dictionary<string, object>
            {
                { "code", value },
                { "msg", value.GetDescription(formatValue) }
            };
            if (data != null)
            {
                foreach (var item in data)
                {
                    jsonData[item.Key] = item.Value;
                }
            }         
            return new JsonResult(jsonData);
        }
        public static string GetJsonString(Enum value, Dictionary<string, object> data = null, string formatValue = "")
        {
            var jsonData = new Dictionary<string, object>
            {
                { "code", value },
                { "msg", value.GetDescription(formatValue) }
            };
            if (data != null)
            {
                foreach (var item in data)
                {
                    jsonData[item.Key] = item.Value;
                }
            }
            return JsonConvert.SerializeObject(jsonData);
        }
        public static T Get<T>(string collectionName, string id) where T : class, new()
        {
            string url = APICallHelper.DOMAIN + $"{collectionName}/{id}";
            HttpService service = new HttpService(url);
            string json = service.getJson();
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            return ConvertService.Instance.convertToObjectFromJson<T>(json);
        }
        public static string GetStringValue(string path)
        {
            string url = APICallHelper.DOMAIN + path;
            HttpService service = new HttpService(url);
            string json = service.getJson();
            if(json.StartsWith("\""))
                json = json.Substring(1);
            if(json.EndsWith("\""))
                json = json.Substring(0, json.Length - 1);
            return json;
        }
        public static List<T> Gets<T>(string path) where T : class, new()
        {
            string url = APICallHelper.DOMAIN + path;
            HttpService service = new HttpService(url);
            string json = service.getJson();
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            return ConvertService.Instance.convertToObjectFromJson<List<T>>(json);
        }
    }
}
