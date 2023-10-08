using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Helper
{
    public class HttpService
    {
        string url;
        public HttpService(string url) {
            this.url = url;
        }
        public string getJson()
        {
            try
            {
                var response = new HttpClient().GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
