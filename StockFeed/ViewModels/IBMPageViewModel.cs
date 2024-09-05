using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class IBMPageViewModel : ObservableObject
    {
        private readonly IBMService _ibmService;
        public ObservableCollection<IBMData> ModelViewIBMData { get; } = new();
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
}