using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class AppleQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public AppleData GlobalQuote { get; set; }
    }
}
