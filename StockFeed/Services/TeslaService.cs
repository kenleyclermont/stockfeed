using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class TeslaService : ObservableObject
    {
        private ObservableCollection<TeslaData> teslaInformation = new ObservableCollection<TeslaData>();
        private const string TESLA_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=TSLA&apikey=7MOV1V3G1529YV1T";
        public TeslaService()
        {
        }
        private async Task<List<TeslaData>> FetchTeslaData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var teslaInfo = JsonConvert.DeserializeObject<TeslaQuoteResponse>(jsonResponse);
                    return new List<TeslaData> { teslaInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Tesla data.");
                }
            }
        }
        public async Task LoadTeslaData()
        {
            try
            {
                var teslaInfo = await FetchTeslaData(TESLA_URL);
                teslaInformation.Clear();
                foreach (var info in teslaInfo)
                {
                    teslaInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<TeslaData>> GetTeslaInformationOnline()
        {
            await LoadTeslaData();
            return teslaInformation;
        }
    }
}

