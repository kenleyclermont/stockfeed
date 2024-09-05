using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class CocaColaPageViewModel : ObservableObject
    {
        private readonly CocaColaService _cocaColaService;
        public ObservableCollection<CocaColaData> ModelViewCocaColaData { get; } = new();
        public CocaColaPageViewModel(CocaColaService cocaColaService)
        {
            _cocaColaService = cocaColaService;
            InitializeModelViewCocaColaData();
        }

        private async void InitializeModelViewCocaColaData()
        {
            ModelViewCocaColaData.Clear();
            var cocaColaInfoOnline = await _cocaColaService.GetCocaColaInformationOnline();
            foreach (var info in cocaColaInfoOnline)
            {
                ModelViewCocaColaData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
