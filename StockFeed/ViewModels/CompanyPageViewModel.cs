using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;

namespace StockFeed.ViewModels
{
    public partial class CompanyPageViewModel : ObservableObject
    {
        public CompanyPageViewModel() { }
    }
    public partial class IBMPageViewModel : CompanyPageViewModel
    {
        private readonly IBMService _ibmService;
        public ObservableCollection<IBMCompany> ModelViewIBMData { get; } = new();

        public IBMPageViewModel(IBMService ibmService)
        {
            _ibmService = ibmService;

            InitializeModelViewIBMData();
        }
        private async void InitializeModelViewIBMData()
        {
            ModelViewIBMData.Clear();
            var ibmInfoOnline = await _ibmService.GetIBMInformationOnline();
            foreach (var info in ibmInfoOnline)
            {
                ModelViewIBMData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }

    public partial class ApplePageViewModel : CompanyPageViewModel
    {
        private readonly AppleService _appleService;
        public ObservableCollection<AppleCompany> ModelViewAppleData { get; } = new();
        public ApplePageViewModel(AppleService appleService)
        {
            _appleService = appleService;

            InitializeModelViewAppleData();
        }
        private async void InitializeModelViewAppleData()
        {
            ModelViewAppleData.Clear();
            var appleInfoOnline = await _appleService.GetAppleInformationOnline();
            foreach (var info in appleInfoOnline)
            {
                ModelViewAppleData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
    public partial class AmazonPageViewModel : CompanyPageViewModel
    {
        public AmazonPageViewModel()
        {


        }
    }
    public partial class FacebookPageViewModel : CompanyPageViewModel
    {
        public FacebookPageViewModel()
        {


        }
    }
    public partial class TeslaPageViewModel : CompanyPageViewModel
    {
        public TeslaPageViewModel()
        {


        }
    }
    public partial class NetflixPageViewModel : CompanyPageViewModel
    {
        public NetflixPageViewModel()
        {


        }
    }
    public partial class AlibabaPageViewModel : CompanyPageViewModel
    {
        public AlibabaPageViewModel()
        {


        }
    }
}

