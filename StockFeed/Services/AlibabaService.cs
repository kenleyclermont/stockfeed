using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class AlibabaService : ObservableObject
    {
        private ObservableCollection<AlibabaData> alibabaInformation = new ObservableCollection<AlibabaData>();
        private const string ALIBABA_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=BABA&apikey=7MOV1V3G1529YV1T";
        public AlibabaService()
        {
        }
        private async Task<List<AlibabaData>> FetchAlibabaData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var alibabaInfo = JsonConvert.DeserializeObject<AlibabaQuoteResponse>(jsonResponse);
                    return new List<AlibabaData> { alibabaInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Alibaba data.");
                }
            }
        }
        public async Task LoadAlibabaData()
        {
            try
            {
                var alibabaInfo = await FetchAlibabaData(ALIBABA_URL);
                alibabaInformation.Clear();
                foreach (var info in alibabaInfo)
                {
                    alibabaInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<AlibabaData>> GetAlibabaInformationOnline()
        {
            await LoadAlibabaData();
            return alibabaInformation;
        }
    }
}

