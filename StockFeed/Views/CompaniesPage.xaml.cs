using StockFeed.ViewModels;
namespace StockFeed.Views;

public partial class CompaniesPage : ContentPage
{
    public CompaniesPage(CompaniesPageViewModel CompaniesPageViewModel)
    {
        InitializeComponent();
        BindingContext = CompaniesPageViewModel;
    }
}