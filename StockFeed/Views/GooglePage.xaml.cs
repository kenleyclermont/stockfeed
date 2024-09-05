using StockFeed.ViewModels;

namespace StockFeed.Views;
public partial class GooglePage : ContentPage
{
    public GooglePage(GooglePageViewModel googlePageViewModel)
    {
        InitializeComponent();
        BindingContext = googlePageViewModel;
    }
}