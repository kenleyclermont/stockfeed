using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class ApplePageViewModel : ObservableObject
    {
        private readonly AppleService _appleService;
        public ObservableCollection<AppleData> ModelViewAppleData { get; } = new();
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
}