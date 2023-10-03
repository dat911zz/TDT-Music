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

namespace TDT.Core.Ultils
{
    public static class APIHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static JsonResult GetJsonResult(Enum value, Dictionary<string, object> data = null)
        {
            var jsonData = new Dictionary<string, object>
            {
                { "code", value },
                { "msg", APIHelper.GetEnumDescription(value) }
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
    }
}
