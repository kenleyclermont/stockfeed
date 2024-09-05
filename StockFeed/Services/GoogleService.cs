using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class GoogleService : ObservableObject
    {

        private ObservableCollection<GoogleData> googleInformation = new ObservableCollection<GoogleData>();
        private const string GOOGLE_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=GOOGL&apikey=7MOV1V3G1529YV1T";
        public GoogleService()
        {
        }
        private async Task<List<GoogleData>> FetchGoogleData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var googleInfo = JsonConvert.DeserializeObject<GoogleQuoteResponse>(jsonResponse);
                    return new List<GoogleData> { googleInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Google data.");
                }
            }
        }
        public async Task LoadGoogleData()
        {
            try
            {
                var googleInfo = await FetchGoogleData(GOOGLE_URL);
                googleInformation.Clear();
                foreach (var info in googleInfo)
                {
                    googleInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<GoogleData>> GetGoogleInformationOnline()
        {
            await LoadGoogleData();
            return googleInformation;
        }
    }
}

