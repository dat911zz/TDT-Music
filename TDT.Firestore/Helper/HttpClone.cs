using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TDT.Firestore.Helper
{
    public class HttpClone
    {
        private static string DOMAIN = @"https://cringe-mp3-api.vercel.app/api/";
        private static HttpClient HTTP_CLIENT = new HttpClient();
        private static HttpClone _intance;
        private HttpClone() { }
        public static HttpClone Intance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new HttpClone();
                }
                return _intance;
            }
        }

        public Stream CreateFileFromUrl(string fileUrl)
        {
            var response = HTTP_CLIENT.GetAsync(fileUrl).Result;
            return response.Content.ReadAsStreamAsync().Result;
        }

        public async Task<string> getTop100()
        {
            var response = await HTTP_CLIENT.GetAsync(DOMAIN + "top100");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<string> getArtist(string alias)
        {
            var response = await HTTP_CLIENT.GetAsync(DOMAIN + "getArtist/" + alias);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<string> getPlaylist(string id)
        {
            var response = await HTTP_CLIENT.GetAsync(DOMAIN + "getPlaylist/" + id);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<string> getSongInfo(string id)
        {
            var response = await HTTP_CLIENT.GetAsync(DOMAIN + "getSongInfo/" + id);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public string getStreaming(string id)
        {
            var response = HTTP_CLIENT.GetAsync(DOMAIN + "getStreaming/" + id).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        public string getLyric(string id)
        {
            var response = HTTP_CLIENT.GetAsync(DOMAIN + "getLyric/" + id).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public string search(string keyword)
        {
            var response = HTTP_CLIENT.GetAsync(DOMAIN + "search/" + keyword).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public string getJsonFromUrl(string url)
        {
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("zmp3_rqid", "MHwxNC4yNDEdUngMjUwLjEzNnx2MS45LjU3fDE2OTA3NzmUsICxNTk1MTE", "/", @".zingmp3.vn"));
            cookieContainer.Add(new Cookie("zmp3_app_version.1", "1957", "/", @".zingmp3.vn"));
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                UseCookies = true
            };
            HttpClient client = new HttpClient(httpClientHandler);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, be");
            string result = "";
            var response = client.GetAsync(url).Result;
            using (var responseStream = response.Content.ReadAsStreamAsync().Result)
            using (var deflateStream = new GZipStream(responseStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(deflateStream))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
