using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class VisaQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public VisaData GlobalQuote { get; set; }
    }
}
