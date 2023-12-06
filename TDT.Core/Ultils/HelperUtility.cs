using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Models;

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
        public static string GetCompactNum(long num)
        {
            if(num < 0) return string.Empty;
            if (num / 1000000.0 >= 1)
                return Math.Round(new decimal(num / 1000000.0),1) + "M";
            if(num / 1000.0 >= 1)
                return Math.Round(new decimal(num / 1000.0), 1) + "K";
            return num.ToString();
        }
        public static string GetTime(long num)
        {
            if (num < 0) return string.Empty;
            try
            {
                TimeSpan time = TimeSpan.FromSeconds(num);
                return $"{time.Hours} giờ {time.Minutes} phút";
            }
            catch
            {
                return string.Empty;
            }
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
        public static string GetTitleWithRemoveVietnamese(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str.ToLower();
        }
        public static List<string> GetParamsIllegal<T>(List<string> nameParams, T model) where T : class, new()
        {
            List<string> res = new List<string>();
            foreach (var param in nameParams)
            {
                if (!string.IsNullOrEmpty(param))
                {
                    var value = typeof(T).GetProperty(param).GetValue(model, null);
                    if (string.IsNullOrEmpty(value.ToString()) || value.ToString().ToLower().Equals("string"))
                        res.Add(param);
                }
            }
            return res;
        }
        public static IEnumerable<CtrlAction> GetAllControllerAction(this Assembly asm)
        {
            //Assembly asm = asm.GetExecutingAssembly();

            return asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute))
                && method.DeclaringType.FullName.Contains("TDT.CAdmin.Controllers")
                )
                .Select(s => new CtrlAction()
                {
                    Name = s.Name,
                    ActionType = s.DeclaringType.FullName
                });
        }
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder randomString = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                randomString.Append(chars[index]);
            }

            return randomString.ToString();
        }

        public static long GetTicks(DateTime dateTime)
        {
            return (long)dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }
    }
}
