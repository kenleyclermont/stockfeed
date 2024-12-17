using System.Collections.ObjectModel;
//using CommunityToolkit.Mvvm.ComponentModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class CompanyService
    {
        private string API_KEY = "7MOV1V3G1529YV1T";
        protected const string BASE_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={0}&apikey={1}";
        protected const string ibm_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.IBM}&apikey={API_KEY}";
        protected const string apple_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.AAPL}&apikey={API_KEY}";
        protected const string amazon_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.IBM}&apikey={API_KEY}";
        protected const string facebook_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.AAPL}&apikey={API_KEY}";
        protected const string tesla_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.IBM}&apikey={API_KEY}";
        protected const string netflix_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.AAPL}&apikey={API_KEY}";
        protected const string alibaba_url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Company.SYMBOLS.AAPL}&apikey={API_KEY}";

        protected ObservableCollection<IBMCompany> _ibmInformation = new ObservableCollection<IBMCompany>();
        protected ObservableCollection<AppleCompany> _appleInformation = new ObservableCollection<AppleCompany>();
        //protected ObservableCollection<AmazonCompany> _amazonInformation = new ObservableCollection<AmazonCompany>();
        //protected ObservableCollection<FacebookCompany> _facebookInformation = new ObservableCollection<FacebookCompany>();
        //protected ObservableCollection<TeslaCompany> _teslaInformation = new ObservableCollection<TeslaCompany>();
        //protected ObservableCollection<NetflixCompany> _netflixInformation = new ObservableCollection<NetflixCompany>();
        //protected ObservableCollection<AlibabaCompany> _alibabaInformation = new ObservableCollection<AlibabaCompany>();

        public CompanyService() { }

    }
    public class IBMService : CompanyService 
    { 
        public IBMService() { }
        private async Task<List<IBMCompany>> FetchIBMData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var ibmInfo = JsonConvert.DeserializeObject<IBMQuoteResponse>(jsonResponse);

                    return new List<IBMCompany> { ibmInfo.IBMQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch IBM data.");
                }
            }
        }
        public async Task LoadIBMData()
        {
            try
            {
                var ibmInfo = await FetchIBMData(ibm_url);

                _ibmInformation.Clear();
                foreach (var info in ibmInfo)
                {
                    _ibmInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<IBMCompany>> GetIBMInformationOnline()
        {
            await LoadIBMData();
            return _ibmInformation;
        }
    }

    public class AppleService : CompanyService 
    { 
        public AppleService() { }

        private async Task<List<AppleCompany>> FetchAppleData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var appleInfo = JsonConvert.DeserializeObject<AppleQuoteResponse>(jsonResponse);

                    return new List<AppleCompany> { appleInfo.AppleQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Apple data.");
                }
            }
        }
        public async Task LoadAppleData()
        {
            try
            {
                var appleInfo = await FetchAppleData(apple_url);

                _appleInformation.Clear();
                foreach (var info in appleInfo)
                {
                    _appleInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<AppleCompany>> GetAppleInformationOnline()
        {
            await LoadAppleData();
            return _appleInformation;
        }
    }
    public class AmazonService : CompanyService
    {

    }
    public class FacebookService : CompanyService
    {

    }
    public class TeslaService : CompanyService
    {

    }
    public class NetflixService : CompanyService
    {

    }
    public class AlibabaService : CompanyService
    {

    }
}
