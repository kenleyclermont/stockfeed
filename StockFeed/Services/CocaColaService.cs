using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class CocaColaService : ObservableObject
    {
        private ObservableCollection<CocaColaData> cocaColaInformation = new ObservableCollection<CocaColaData>();
        private const string COCACOLA_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=KO&apikey=7MOV1V3G1529YV1T";
        public CocaColaService()
        {
        }
        private async Task<List<CocaColaData>> FetchCocaColaData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var cocaColaInfo = JsonConvert.DeserializeObject<CocaColaQuoteResponse>(jsonResponse);
                    return new List<CocaColaData> { cocaColaInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Coca-Cola data.");
                }
            }
        }
        public async Task LoadCocaColaData()
        {
            try
            {
                var cocaColaInfo = await FetchCocaColaData(COCACOLA_URL);
                cocaColaInformation.Clear();
                foreach (var info in cocaColaInfo)
                {
                    cocaColaInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<CocaColaData>> GetCocaColaInformationOnline()
        {
            await LoadCocaColaData();
            return cocaColaInformation;
        }
    }
}

