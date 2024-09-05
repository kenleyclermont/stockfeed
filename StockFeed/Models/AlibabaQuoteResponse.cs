using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class AlibabaQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public AlibabaData GlobalQuote { get; set; }
    }
}

