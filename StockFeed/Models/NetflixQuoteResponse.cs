using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class NetflixQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public NetflixData GlobalQuote { get; set; }
    }
}
