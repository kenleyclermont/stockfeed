using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class FacebookService : ObservableObject
    {

        private ObservableCollection<FacebookData> facebookInformation = new ObservableCollection<FacebookData>();
        private const string FACEBOOK_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=META&apikey=7MOV1V3G1529YV1T";
        public FacebookService()
        {
        }
        private async Task<List<FacebookData>> FetchFacebookData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var facebookInfo = JsonConvert.DeserializeObject<FacebookQuoteResponse>(jsonResponse);
                    return new List<FacebookData> { facebookInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Facebook data.");
                }
            }
        }
        public async Task LoadFacebookData()
        {
            try
            {
                var facebookInfo = await FetchFacebookData(FACEBOOK_URL);
                facebookInformation.Clear();
                foreach (var info in facebookInfo)
                {
                    facebookInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<FacebookData>> GetFacebookInformationOnline()
        {
            await LoadFacebookData();
            return facebookInformation;
        }
    }
}

