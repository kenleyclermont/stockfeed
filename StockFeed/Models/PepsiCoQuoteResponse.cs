using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class PepsiCoQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public PepsiCoData GlobalQuote { get; set; }
    }
}