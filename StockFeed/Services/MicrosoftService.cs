using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class MicrosoftService : ObservableObject
    {

        private ObservableCollection<MicrosoftData> microsoftInformation = new ObservableCollection<MicrosoftData>();
        private const string MICROSOFT_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=MSFT&apikey=7MOV1V3G1529YV1T";
        public MicrosoftService()
        {
        }
        private async Task<List<MicrosoftData>> FetchMicrosoftData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var microsoftInfo = JsonConvert.DeserializeObject<MicrosoftQuoteResponse>(jsonResponse);
                    return new List<MicrosoftData> { microsoftInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Microsoft data.");
                }
            }
        }
        public async Task LoadMicrosoftData()
        {
            try
            {
                var microsoftInfo = await FetchMicrosoftData(MICROSOFT_URL);
                microsoftInformation.Clear();
                foreach (var info in microsoftInfo)
                {
                    microsoftInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<MicrosoftData>> GetMicrosoftInformationOnline()
        {
            await LoadMicrosoftData();
            return microsoftInformation;
        }
    }
}

