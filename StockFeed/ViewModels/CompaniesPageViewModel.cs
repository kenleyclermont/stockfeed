using StockFeed.Models;
using StockFeed.Views;
using StockFeed.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Data;

namespace StockFeed.ViewModels
{
    public partial class CompaniesPageViewModel : ObservableObject
    {
        private readonly CompaniesService _companiesService;
        private Company currentCompany;
        private string pendingCompanyPage;
        [ObservableProperty]
        private string searchCompany;
        public ObservableCollection<Company> ModelViewCompanies { get; } = new();
        public ObservableCollection<Company> FilteredCompanies { get; } = new();

        public CompaniesPageViewModel(CompaniesService companiesService)
        {
            _companiesService = companiesService;
            ModelViewCompanies = _companiesService.LoadCompanies();
            FilteredCompanies = new ObservableCollection<Company>(ModelViewCompanies);

            this.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(SearchCompany))
                {
                    ApplyFilter();
                }
            };
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(SearchCompany))
            {
                // Reset filter
                FilteredCompanies.Clear();
                foreach (var company in ModelViewCompanies)
                {
                    FilteredCompanies.Add(company);
                }
            }
            else
            {
                var filtered = ModelViewCompanies.Where(c =>
                    c.Name.Contains(SearchCompany, System.StringComparison.OrdinalIgnoreCase) ||
                    c.IdSymbol.Contains(SearchCompany, System.StringComparison.OrdinalIgnoreCase)).ToList();

                FilteredCompanies.Clear();
                foreach (var company in filtered)
                {
                    FilteredCompanies.Add(company);
                }
            }
        }

        [RelayCommand]
        private async Task SelectCurrentCompany(Company company)
        {
            currentCompany = company;
            await SelectCompany(company);
        }

        [RelayCommand]
        private async Task ReloadCompany()
        {
            if (!string.IsNullOrEmpty(pendingCompanyPage))
            {
                if (InternetStatus.IsInternetConnectionOpen())
                {
                    await Shell.Current.GoToAsync(pendingCompanyPage);
                    pendingCompanyPage = null;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Internet is still unavailable. Please try again later.", "OK");
                }
            }
        }

        [RelayCommand]
        private static async Task CancelRequest()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }

        [RelayCommand]
        private static async Task CancelViewCompanies()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        [RelayCommand]
        private async Task SelectCompany(Company company)
        {
            string companyPage = string.Empty;

            switch (company.IdSymbol)
            {
                case Company.SYMBOLS.IBM:
                    companyPage = nameof(IBMPage);
                    break;
                case Company.SYMBOLS.AAPL:
                    companyPage = nameof(ApplePage);
                    break;
                case Company.SYMBOLS.AMZN:
                    companyPage = nameof(AmazonPage);
                    break;
                case Company.SYMBOLS.META:
                    companyPage = nameof(FacebookPage);
                    break;
                case Company.SYMBOLS.TSLA:
                    companyPage = nameof(TeslaPage);
                    break;
                case Company.SYMBOLS.NFLX:
                    companyPage = nameof(NetflixPage);
                    break;
                case Company.SYMBOLS.BABA:
                    companyPage = nameof(AlibabaPage);
                    break;
                default:
                    await Shell.Current.DisplayAlert("Error", "No page available for the selected company.", "OK");
                    return;
            }

            if (InternetStatus.IsInternetConnectionOpen())
            {
                await Shell.Current.GoToAsync(companyPage);
            }
            else
            {
                pendingCompanyPage = companyPage;
                await Shell.Current.GoToAsync(nameof(InternetReloadPage));
            }
        }
    }
}