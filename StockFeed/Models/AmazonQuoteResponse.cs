using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class AmazonQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public AmazonData GlobalQuote { get; set; }
    }
}

