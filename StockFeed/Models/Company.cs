using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
namespace StockFeed.Models
{
    public partial class Company:ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string idSymbol;

        [ObservableProperty]
        private string logoImagePath;

        [JsonProperty("01. symbol")]
        public string Symbol { get; set; }

        [JsonProperty("02. open")]
        public string Open { get; set; }

        [JsonProperty("03. high")]
        public string High { get; set; }

        [JsonProperty("04. low")]
        public string Low { get; set; }

        [JsonProperty("05. price")]
        public string Price { get; set; }

        [JsonProperty("06. volume")]
        public string Volume { get; set; }

        [JsonProperty("07. latest trading day")]
        public string LatestTradingDay { get; set; } 

        [JsonProperty("08. previous close")]
        public string PreviousClose { get; set; }

        [JsonProperty("09. change")]
        public string Change { get; set; }

        [JsonProperty("10. change percent")]
        public string ChangePercent { get; set; }

        public struct SYMBOLS
        {
            public const string IBM = "IBM";
            public const string AAPL = "AAPL";
            public const string AMZN = "AMZN";
            public const string META = "META";
            public const string TSLA = "TSLA";
            public const string NFLX = "NFLX";
            public const string BABA = "BABA";
        }
        public Company() { }
        public Company(string symbol, string name, string logoImagePath) 
        {
            IdSymbol = symbol;
            Name = name;
            LogoImagePath = logoImagePath;
        }
    }

    public class IBMCompany : Company
    { 
        public IBMCompany():base("IBM", "IBM","ibm.png") { }
    }
    public class AppleCompany : Company
    {
        public AppleCompany() : base("AAPL", "Apple Inc.", "apple.png") { }
    }
    public class AmazonCompany : Company
    {
        public AmazonCompany() : base("AMZN", "Amazon", "amazon.png") { }
    }
    public class FacebookCompany : Company
    {
        public FacebookCompany() : base("META", "Facebook", "facebook.png") { }
    }
    public class TeslaCompany : Company
    {
        public TeslaCompany() : base("TSLA", "Tesla", "tesla.png") { }
    }
    public class NetflixCompany : Company
    {
        public NetflixCompany() : base("NFLX", "Netflix", "netflix.png") { }
    }
    public class AlibabaCompany : Company
    {
        public AlibabaCompany() : base("BABA", "Alibaba", "alibaba.png") { }
    }
}
