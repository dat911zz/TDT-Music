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
    }
}
