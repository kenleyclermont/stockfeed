using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class AmazonService : ObservableObject
    {

        private ObservableCollection<AmazonData> amazonInformation = new ObservableCollection<AmazonData>();
        private const string AMAZON_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=AMZN&apikey=7MOV1V3G1529YV1T";
        public AmazonService()
        {
        }
        private async Task<List<AmazonData>> FetchAmazonData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var amazonInfo = JsonConvert.DeserializeObject<AmazonQuoteResponse>(jsonResponse);
                    return new List<AmazonData> { amazonInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Amazon data.");
                }
            }
        }
        public async Task LoadAmazonData()
        {
            try
            {
                var amazonInfo = await FetchAmazonData(AMAZON_URL);
                amazonInformation.Clear();
                foreach (var info in amazonInfo)
                {
                    amazonInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<AmazonData>> GetAmazonInformationOnline()
        {
            await LoadAmazonData();
            return amazonInformation;
        }
    }
}

