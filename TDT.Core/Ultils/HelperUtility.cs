using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Ultils
{
    public static class HelperUtility
    {
        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        public static string getBetweenDate(DateTime dt)
        {
            string res = "{0} {1} trước";
            DateTime now = DateTime.Now;
            if (now.Year - dt.Year > 0)
                return string.Format(res, now.Year - dt.Year, "năm");
            if (now.Month - dt.Month > 0)
                return string.Format(res, now.Month - dt.Month, "tháng");
            if (now.Day - dt.Day > 0)
                return string.Format(res, now.Day - dt.Day, "ngày");
            if (now.Hour - dt.Hour > 0)
                return string.Format(res, now.Hour - dt.Hour, "giờ");
            if (now.Minute - dt.Minute > 0)
                return string.Format(res, now.Minute - dt.Minute, "phút");
            if (now.Second - dt.Second > 0)
                return string.Format(res, now.Second - dt.Second, "giây");
            return "Vừa xong";
        }
        public static string GetAlias(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str.ToLower().Replace(" ", "-");
        }
        public static List<string> GetParamsIllegal<T>(List<string> nameParams, T model) where T : class, new()
        {
            List<string> res = new List<string>();
            foreach (var param in nameParams)
            {
                if(!string.IsNullOrEmpty(param))
                {
                    var value = typeof(T).GetProperty(param).GetValue(model, null);
                    if (string.IsNullOrEmpty(value.ToString()) || value.ToString().ToLower().Equals("string"))
                        res.Add(param);
                }
            }
            return res;
        }
    }
}
