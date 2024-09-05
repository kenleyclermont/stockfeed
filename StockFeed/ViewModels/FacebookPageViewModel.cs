using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using StockFeed.Models;
using StockFeed.Services;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;
namespace StockFeed.ViewModels
{
    public partial class FacebookPageViewModel : ObservableObject
    {
        private readonly FacebookService _facebookService;
        public ObservableCollection<FacebookData> ModelViewFacebookData { get; } = new();
        public FacebookPageViewModel(FacebookService facebookService)
        {
            _facebookService = facebookService;
            InitializeModelViewFacebookData();
        }
        private async void InitializeModelViewFacebookData()
        {
            ModelViewFacebookData.Clear();
            var facebookInfoOnline = await _facebookService.GetFacebookInformationOnline();
            foreach (var info in facebookInfoOnline)
            {
                ModelViewFacebookData.Add(info);
            }
        }
        [RelayCommand]
        private async Task BackToCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
