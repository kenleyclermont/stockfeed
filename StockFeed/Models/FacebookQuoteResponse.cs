using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class FacebookQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public FacebookData GlobalQuote { get; set; }
    }
}
