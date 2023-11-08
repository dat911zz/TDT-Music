using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
//using Microsoft.Data.Sql;

namespace TDT.QLDV
{
    public static class ConfigHelper
    {
        public static DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            //dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public static DataTable GetDBName(string serverName, string userName, string pass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select name from sys.Databases", "Data Source=" + serverName + ";Initial Catalog=master;User ID=" + userName + ";pwd=" + pass + "");
            da.Fill(dt);
            return dt;
        }
        public static void SaveConfig(string connStrName, string newConnectionString)
        {
            var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());

            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);

            var expandoDict = config as IDictionary<string, object>;
            IDictionary<string, object> result = new ExpandoObject();
            result[connStrName] = newConnectionString;
            expandoDict["ConnectionStrings"] = result;

            config = expandoDict;

            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
            File.WriteAllText(appSettingsPath, newJson);
        }
    }
}
