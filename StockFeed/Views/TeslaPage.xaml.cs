using StockFeed.ViewModels;

namespace StockFeed.Views;

public partial class TeslaPage : ContentPage
{
	public TeslaPage(TeslaPageViewModel teslaPageViewModel)
	{
		InitializeComponent();
		BindingContext = teslaPageViewModel;
	}
}