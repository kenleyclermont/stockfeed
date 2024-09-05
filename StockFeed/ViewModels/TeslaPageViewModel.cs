using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class TeslaPageViewModel : ObservableObject
    {
        private readonly TeslaService _teslaService;
        public ObservableCollection<TeslaData> ModelViewTeslaData { get; } = new();
        public TeslaPageViewModel(TeslaService teslaService)
        {
            _teslaService = teslaService;
            InitializeModelViewTeslaData();
        }

        private async void InitializeModelViewTeslaData()
        {
            ModelViewTeslaData.Clear();
            var teslaInfoOnline = await _teslaService.GetTeslaInformationOnline();
            foreach (var info in teslaInfoOnline)
            {
                ModelViewTeslaData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
