using StockFeed.ViewModels;

namespace StockFeed.Views;

public partial class VisaPage : ContentPage
{
	public VisaPage(VisaPageViewModel visaPageViewModel)
	{
		InitializeComponent();
		BindingContext = visaPageViewModel;
	}
}