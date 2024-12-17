using StockFeed.ViewModels;
namespace StockFeed.Views;
public partial class ApplePage : ContentPage
{
    public ApplePage(ApplePageViewModel applePageViewModel)
    {
        InitializeComponent();
        BindingContext = applePageViewModel;
    }
}