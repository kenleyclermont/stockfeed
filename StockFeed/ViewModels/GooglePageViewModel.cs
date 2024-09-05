using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class GooglePageViewModel : ObservableObject
    {
        private readonly GoogleService _googleService;
        public ObservableCollection<GoogleData> ModelViewGoogleData { get; } = new();
        public GooglePageViewModel(GoogleService googleService)
        {
            _googleService = googleService;

            InitializeModelViewGoogleData();
        }
        private async void InitializeModelViewGoogleData()
        {
            ModelViewGoogleData.Clear();
            var googleInfoOnline = await _googleService.GetGoogleInformationOnline();
            foreach (var info in googleInfoOnline)
            {
                ModelViewGoogleData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}