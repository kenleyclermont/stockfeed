using StockFeed.ViewModels;
namespace StockFeed.Views;
public partial class MicrosoftPage : ContentPage
{
    public MicrosoftPage(MicrosoftPageViewModel microsoftPageViewModel)
    {
        InitializeComponent();
        BindingContext = microsoftPageViewModel;
    }
}