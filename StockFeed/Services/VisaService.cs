using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using Newtonsoft.Json;

namespace StockFeed.Services
{
    public class VisaService : ObservableObject
    {
        private ObservableCollection<VisaData> visaInformation = new ObservableCollection<VisaData>();
        private const string VISA_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=V&apikey=7MOV1V3G1529YV1T";
        public VisaService()
        {
        }
        private async Task<List<VisaData>> FetchVisaData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var VisaInfo = JsonConvert.DeserializeObject<VisaQuoteResponse>(jsonResponse);
                    return new List<VisaData> { VisaInfo.GlobalQuote };
                }
                else
                {
                    throw new Exception("Failed to fetch Visa data.");
                }
            }
        }
        public async Task LoadVisaData()
        {
            try
            {
                var visaInfo = await FetchVisaData(VISA_URL);
                visaInformation.Clear();
                foreach (var info in visaInfo)
                {
                    visaInformation.Add(info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<ObservableCollection<VisaData>> GetVisaInformationOnline()
        {
            await LoadVisaData();
            return visaInformation;
        }
    }
}

