using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class NetflixPageViewModel : ObservableObject
    {
        private readonly NetflixService _netflixService;
        public ObservableCollection<NetflixData> ModelViewNetflixData { get; } = new();
        public NetflixPageViewModel(NetflixService netflixService)
        {
            _netflixService = netflixService;
            InitializeModelViewNetflixData();
        }

        private async void InitializeModelViewNetflixData()
        {
            ModelViewNetflixData.Clear();
            var netflixInfoOnline = await _netflixService.GetNetflixInformationOnline();
            foreach (var info in netflixInfoOnline)
            {
                ModelViewNetflixData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
