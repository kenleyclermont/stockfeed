using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StockFeed.Views;

namespace StockFeed.ViewModels
{
    public partial class MainPageViewModel: ObservableObject
    {
        public MainPageViewModel() 
        {
        }

        [RelayCommand]
        private static async Task ViewCompanies()
        {
            await Shell.Current.GoToAsync(nameof(CompaniesPage));
        }
    }
}
