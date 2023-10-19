using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Helper
{
    public class StorgeService
    {
        private StorgeService() { }
        private static StorgeService instance;
        public static StorgeService Instance
        {
            get
            {
                if (instance == null)
                    instance = new StorgeService();
                return instance;
            }
        }


        public Stream CreateFileFromUrl(string fileUrl)
        {
            var response = new HttpClient().GetAsync(fileUrl).Result;
            return response.Content.ReadAsStreamAsync().Result;
        }
    }
}
