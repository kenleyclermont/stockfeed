using StockFeed.ViewModels;

namespace StockFeed.Views;

public partial class WalmartPage : ContentPage
{
	public WalmartPage(WalmartPageViewModel walmartPageViewModel)
	{
		InitializeComponent();
		BindingContext = walmartPageViewModel;
	}
}