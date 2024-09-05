using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class WalmartService : ObservableObject
    {
        private ObservableCollection<WalmartData> walmartInformation = new ObservableCollection<WalmartData>();
        private const string WALMART_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=WMT&apikey=7MOV1V3G1529YV1T";
        public WalmartService()
        {
        }
        private async Task<List<WalmartData>> FetchWalmartData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var walmartInfo = JsonConvert.DeserializeObject<WalmartQuoteResponse>(jsonResponse);
                    return new List<WalmartData> { walmartInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Visa data.");
                }
            }
        }
        public async Task LoadWalmartData()
        {
            try
            {
                var walmartInfo = await FetchWalmartData(WALMART_URL);
                walmartInformation.Clear();
                foreach (var info in walmartInfo)
                {
                    walmartInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<WalmartData>> GetWalmartInformationOnline()
        {
            await LoadWalmartData();
            return walmartInformation;
        }
    }
}

