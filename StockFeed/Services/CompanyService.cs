using StockFeed.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StockFeed.Services
{
    public class CompanyService : ObservableObject
    {
        private ObservableCollection<Company> companies = new();
        public CompanyService()
        {
        }
        
        public ObservableCollection<Company> LoadCompanies()
        {
            if (companies.Count == 0)
            {
                companies.Add(new Company(id: 1, companyName: "IBM",  companySymbol:"IBM", companyLogo:"ibm.png"));
                companies.Add(new Company(id: 2, companyName: "Apple", companySymbol: "AAPL", companyLogo: "apple.png"));
                companies.Add(new Company(id: 3, companyName: "Microsoft", companySymbol: "MSFT", companyLogo: "microsoft.png"));
                companies.Add(new Company(id: 4, companyName: "Google", companySymbol: "GOOGL", companyLogo: "google.png"));
                companies.Add(new Company(id: 5, companyName: "Amazon", companySymbol: "AMZN", companyLogo: "amazon.png"));
                companies.Add(new Company(id: 6, companyName: "Facebook", companySymbol: "META", companyLogo: "facebook.png"));
                companies.Add(new Company(id: 7, companyName: "Tesla", companySymbol: "TSLA", companyLogo: "tesla.png"));
                companies.Add(new Company(id: 8, companyName: "Netflix", companySymbol: "NFLX", companyLogo: "netflix.png"));
                companies.Add(new Company(id: 9, companyName: "Alibaba", companySymbol: "BABA", companyLogo: "alibaba.png"));
                companies.Add(new Company(id: 10, companyName: "Coca-Cola", companySymbol: "KO", companyLogo: "cocacola.png"));
                companies.Add(new Company(id: 11, companyName: "PepsiCo", companySymbol: "PEP", companyLogo: "pepsico.png"));
                companies.Add(new Company(id: 12, companyName: "Visa", companySymbol: "V", companyLogo: "visa.png"));
                companies.Add(new Company(id: 13, companyName: "Walmart", companySymbol: "WMT", companyLogo: "walmart.png"));               
            }
            return companies;
        }
    }
}
