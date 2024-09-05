using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class WalmartQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public WalmartData GlobalQuote { get; set; }
    }
}
