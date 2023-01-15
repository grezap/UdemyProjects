using Newtonsoft.Json;

namespace KafkaConsumer.Model
{
    public class AfterId
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }
}
