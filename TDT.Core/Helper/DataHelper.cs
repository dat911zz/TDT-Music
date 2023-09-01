using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.Enum;

namespace TDT.Core.Helper
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private DataHelper() { }
        public static DataHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataHelper();
                return _instance;
            }
        }

        #region Const
        public static ViewColor VIEW_COLOR = ViewColor.BLACK;
        #endregion
    }
}
