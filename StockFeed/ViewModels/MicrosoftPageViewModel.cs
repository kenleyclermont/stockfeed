using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class MicrosoftPageViewModel : ObservableObject
    {
        private readonly MicrosoftService _microsoftService;
        public ObservableCollection<MicrosoftData> ModelViewMicrosoftData { get; } = new();
        public MicrosoftPageViewModel(MicrosoftService microsoftService)
        {
            _microsoftService = microsoftService;

            InitializeModelViewMicrosoftData();
        }
        private async void InitializeModelViewMicrosoftData()
        {
            ModelViewMicrosoftData.Clear();
            var microsoftInfoOnline = await _microsoftService.GetMicrosoftInformationOnline();
            foreach (var info in microsoftInfoOnline)
            {
                ModelViewMicrosoftData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}