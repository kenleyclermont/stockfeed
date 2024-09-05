using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class PepsiCoPageViewModel : ObservableObject
    {
        private readonly PepsiCoService _pepsiCoService;
        public ObservableCollection<PepsiCoData> ModelViewPepsiCoData { get; } = new();
        public PepsiCoPageViewModel(PepsiCoService pepsiCoService)
        {
            _pepsiCoService = pepsiCoService;
            InitializeModelViewPepsiCoData();
        }
        private async void InitializeModelViewPepsiCoData()
        {
            ModelViewPepsiCoData.Clear();
            var pepsiCoInfoOnline = await _pepsiCoService.GetPepsiCoInformationOnline();
            foreach (var info in pepsiCoInfoOnline)
            {
                ModelViewPepsiCoData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
