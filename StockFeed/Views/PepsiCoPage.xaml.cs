using StockFeed.ViewModels;

namespace StockFeed.Views;

public partial class PepsiCoPage : ContentPage
{
	public PepsiCoPage(PepsiCoPageViewModel	pepsiCoPageViewModel)
	{
		InitializeComponent();
		BindingContext = pepsiCoPageViewModel;
	}
}