using Newtonsoft.Json;

namespace Poolit.Models
{
    [Serializable]
    public class DataEntry<T> : IDataEntry
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
