using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class AlibabaPageViewModel : ObservableObject
    {
        private readonly AlibabaService _alibabaService;
        public ObservableCollection<AlibabaData> ModelViewAlibabaData { get; } = new();
        public AlibabaPageViewModel(AlibabaService alibabaService)
        {
            _alibabaService = alibabaService;
            InitializeModelViewAlibabaData();
        }
        private async void InitializeModelViewAlibabaData()
        {
            ModelViewAlibabaData.Clear();
            var alibabaInfoOnline = await _alibabaService.GetAlibabaInformationOnline();
            foreach (var info in alibabaInfoOnline)
            {
                ModelViewAlibabaData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
