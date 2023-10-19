using Newtonsoft.Json;

namespace TDT.Firestore.ModelClone
{
    public class GetStream
    {
        public int err { get; set; }
        public string msg { get; set; }
        public string url { get; set; }
        public Data data { get; set; }
        public string timestamp { get; set; }
    }
    public class Data
    {
        [JsonProperty("128")]
        public string _128 { get; set; }

        [JsonProperty("320")]
        public string _320 { get; set; }
    }

}
