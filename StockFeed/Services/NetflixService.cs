using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class NetflixService : ObservableObject
    {
        private ObservableCollection<NetflixData> netflixInformation = new ObservableCollection<NetflixData>();
        private const string NETFLIX_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=NFLX&apikey=7MOV1V3G1529YV1T";
        public NetflixService()
        {
        }
        private async Task<List<NetflixData>> FetchNetflixData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var netflixInfo = JsonConvert.DeserializeObject<NetflixQuoteResponse>(jsonResponse);
                    return new List<NetflixData> { netflixInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Netflix data.");
                }
            }
        }
        public async Task LoadNetflixData()
        {
            try
            {
                var netflixInfo = await FetchNetflixData(NETFLIX_URL);
                netflixInformation.Clear();
                foreach (var info in netflixInfo)
                {
                    netflixInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<NetflixData>> GetNetflixInformationOnline()
        {
            await LoadNetflixData();
            return netflixInformation;
        }
    }
}

