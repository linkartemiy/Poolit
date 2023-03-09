using Newtonsoft.Json;

namespace Poolit.Models
{
    [Serializable]
    public class Response
    {
        [JsonProperty("data")]
        public IDataEntry[] Data { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
