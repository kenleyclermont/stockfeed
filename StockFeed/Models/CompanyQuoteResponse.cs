using Newtonsoft.Json;
namespace StockFeed.Models
{
    public class CompanyQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public Company GlobalQuote { get; set; }
    }
    public class IBMQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public IBMCompany IBMQuote { get; set; }
    }
    public class AppleQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public AppleCompany AppleQuote { get; set; }
    }
    public class AmazonQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public AmazonCompany AmazonQuote { get; set; }
    }
    public class FacebookQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public FacebookCompany FacebookQuote { get; set; }
    }
    public class TeslaQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public TeslaCompany TeslaQuote { get; set; }
    }
    public class NetflixQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public NetflixCompany NetflixQuote { get; set; }
    }
    public class AlibabaQuoteResponse
    {
        [JsonProperty("Global Quote")]
        public AlibabaCompany AlibabaQuote { get; set; }
    }
}
