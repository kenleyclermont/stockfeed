using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace StockFeed.Services
{
    public class AppleService : ObservableObject
    {
        private ObservableCollection<AppleData> _appleInformation = new ObservableCollection<AppleData>();
        private const string APPLE_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=AAPL&apikey=7MOV1V3G1529YV1T";

        public AppleService()
        {
        }

        private async Task<List<AppleData>> FetchAppleData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var appleInfo = JsonConvert.DeserializeObject<AppleQuoteResponse>(jsonResponse);

                    return new List<AppleData> { appleInfo.GlobalQuote };
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
                var appleInfo = await FetchAppleData(APPLE_URL);

                // Clear the existing data
                _appleInformation.Clear();

                // Add the fetched data to the ObservableCollection
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

        public async Task<ObservableCollection<AppleData>> GetAppleInformationOnline()
        {
            await LoadAppleData();
            return _appleInformation;
        }
    }
}