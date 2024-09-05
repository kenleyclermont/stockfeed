using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class VisaPageViewModel : ObservableObject
    {
        private readonly VisaService _visaService;
        public ObservableCollection<VisaData> ModelViewVisaData { get; } = new();
        public VisaPageViewModel(VisaService visaService)
        {
            _visaService = visaService;
            InitializeModelViewVisaData();
        }

        private async void InitializeModelViewVisaData()
        {
            ModelViewVisaData.Clear();
            var visaInfoOnline = await _visaService.GetVisaInformationOnline();
            foreach (var info in visaInfoOnline)
            {
                ModelViewVisaData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
