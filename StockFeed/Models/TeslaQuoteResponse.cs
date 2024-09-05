using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class TeslaQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public TeslaData GlobalQuote { get; set; }
    }
}
