using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class AmazonPageViewModel : ObservableObject
    {
        private readonly AmazonService _amazonService;
        public ObservableCollection<AmazonData> ModelViewAmazonData { get; } = new();
        public AmazonPageViewModel(AmazonService amazonService)
        {
            _amazonService = amazonService;

            InitializeModelViewAmazonData();
        }

        private async void InitializeModelViewAmazonData()
        {
            ModelViewAmazonData.Clear();
            var amazonInfoOnline = await _amazonService.GetAmazonInformationOnline();
            foreach (var info in amazonInfoOnline)
            {
                ModelViewAmazonData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
