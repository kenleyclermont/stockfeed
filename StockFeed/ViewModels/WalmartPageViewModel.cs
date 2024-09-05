using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class WalmartPageViewModel : ObservableObject
    {
        private readonly WalmartService _walmartService;
        public ObservableCollection<WalmartData> ModelViewWalmartData { get; } = new();
        public WalmartPageViewModel(WalmartService walmartService)
        {
            _walmartService = walmartService;
            InitializeModelViewWalmartData();
        }

        private async void InitializeModelViewWalmartData()
        {
            ModelViewWalmartData.Clear();
            var walmartInfoOnline = await _walmartService.GetWalmartInformationOnline();
            foreach (var info in walmartInfoOnline)
            {
                ModelViewWalmartData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
