using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class MicrosoftQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public MicrosoftData GlobalQuote { get; set; }
    }
}

