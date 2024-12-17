using StockFeed.ViewModels;
namespace StockFeed.Views;

public partial class AmazonPage : ContentPage
{
	public AmazonPage(AmazonPageViewModel amazonPageViewModel)
	{
		InitializeComponent();
		BindingContext = amazonPageViewModel;
	}
}