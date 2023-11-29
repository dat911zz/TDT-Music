using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TDT.QLDV.Extensions;

namespace TDT.QLDV.Ultils
{
    public static class APIHelper
    {
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
