using StockFeed.ViewModels;

namespace StockFeed.Views;

public partial class InternetReloadPage : ContentPage
{
	public InternetReloadPage(CompaniesPageViewModel companiesPageViewModel)
	{
		InitializeComponent();
		BindingContext = companiesPageViewModel;
	}
}