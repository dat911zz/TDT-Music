using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Ultils
{
    public class HelperUtility
    {
        private HelperUtility() { }
        private static HelperUtility _instance;
        public static HelperUtility Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HelperUtility();
                return _instance;
            }
        }

        public string getBetweenDate(DateTime dt)
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
    }
}
