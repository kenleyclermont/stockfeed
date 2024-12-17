using StockFeed.ViewModels;
namespace StockFeed.Views;

public partial class NetflixPage : ContentPage
{
	public NetflixPage(NetflixPageViewModel netflixPageViewModel)
	{
		InitializeComponent();
		BindingContext = netflixPageViewModel;
	}
}