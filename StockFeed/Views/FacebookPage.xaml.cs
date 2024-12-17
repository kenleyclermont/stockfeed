using StockFeed.ViewModels;

namespace StockFeed.Views;

public partial class FacebookPage : ContentPage
{
	public FacebookPage(FacebookPageViewModel facebookPageViewModel)
	{
		InitializeComponent();
		BindingContext = facebookPageViewModel;
	}
}