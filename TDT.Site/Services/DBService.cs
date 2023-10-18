using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT_Music.Services
{
    public class DBService
    {
        private static DBService _instance;
        private DBService() { }
        public static DBService Instance
        {
            get
            {
                if( _instance == null )
                    _instance = new DBService();
                return _instance;
            }
        }
        /// <summary>
        /// path: đường dẫn trên firebase => Song/ZZ5RTT
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public T getFirebase<T>(string path) where T : class, new()
        {
            string url = APICallHelper.DOMAIN + path;
            HttpService service = new HttpService(url);
            string json = service.getJson();
            if(string.IsNullOrEmpty(json))
            {
                return null;
            }
            return ConvertService.Instance.convertToObjectFromJson<T>(json);
        }
    }
}
