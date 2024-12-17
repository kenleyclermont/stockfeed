using StockFeed.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
namespace StockFeed.Services
{
    public class CompaniesService: ObservableObject
    {
        private ObservableCollection<Company> Companies = new(); 
        public CompaniesService() { }
        public ObservableCollection<Company> LoadCompanies()
        {

            if (Companies.Count() == 0)
            { 
                Companies.Add(new IBMCompany());
                Companies.Add(new AppleCompany());
                Companies.Add(new AmazonCompany());
                Companies.Add(new FacebookCompany());
                Companies.Add(new TeslaCompany());
                Companies.Add(new NetflixCompany());
                Companies.Add(new AlibabaCompany());
            }
            return Companies;
        }
    }
}
