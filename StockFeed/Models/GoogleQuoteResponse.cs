using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class GoogleQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public GoogleData GlobalQuote { get; set; }
    }
}
