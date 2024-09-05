using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class PepsiCoService : ObservableObject
    {
        private ObservableCollection<PepsiCoData> pepsiCoInformation = new ObservableCollection<PepsiCoData>();
        private const string PEPSICO_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=PEP&apikey=7MOV1V3G1529YV1T";
        public PepsiCoService()
        {
        }
        private async Task<List<PepsiCoData>> FetchPepsiCoData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var pepsiCoInfo = JsonConvert.DeserializeObject<PepsiCoQuoteResponse>(jsonResponse);
                    return new List<PepsiCoData> { pepsiCoInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch PepsiCo data.");
                }
            }
        }
        public async Task LoadPepsiCoData()
        {
            try
            {
                var cocaColaInfo = await FetchPepsiCoData(PEPSICO_URL);
                pepsiCoInformation.Clear();
                foreach (var info in cocaColaInfo)
                {
                    pepsiCoInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<PepsiCoData>> GetPepsiCoInformationOnline()
        {
            await LoadPepsiCoData();
            return pepsiCoInformation;
        }
    }
}

