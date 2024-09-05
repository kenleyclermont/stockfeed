using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class CocaColaQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public CocaColaData GlobalQuote { get; set; }
    }
}
