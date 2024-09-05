using CommunityToolkit.Mvvm.ComponentModel;

namespace StockFeed.Models
{
    public partial class Company :ObservableObject
    {

        public int id { get; set; }

        [ObservableProperty]
        public string companyName;
        [ObservableProperty]
        public string companySymbol;
        [ObservableProperty]
        public string companyLogo;

        public struct SYMBOLS
        {
            public const string IBM = "IBM";
            public const string AAPL = "AAPL";
            public const string MSFT = "MSFT";
            public const string GOOGL = "GOOGL";
            public const string AMZN = "AMZN";
            public const string META = "META";
            public const string TSLA = "TSLA";
            public const string NFLX = "NFLX";
            public const string BABA = "BABA";
            public const string KO = "KO";
            public const string PEP = "PEP";
            public const string V = "V";
            public const string WMT = "WMT";
        }
        public Company()
        {

        }
        public Company(int id, string companyName, string companySymbol, string companyLogo)
        {
            this.id = id;
            this.companyName = companyName;
            this.companySymbol = companySymbol;
            this.companyLogo = companyLogo;
        }
        public Company(string companyName, string companySymbol,  string companyLogo)
        {
            this.companyName = companyName;
            this.companySymbol = companySymbol;
            this.companyLogo = companyLogo;
        }
    }
}