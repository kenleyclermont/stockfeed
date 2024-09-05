using StockFeed.ViewModels;
namespace StockFeed.Views;

public partial class CocaColaPage : ContentPage
{
	public CocaColaPage(CocaColaPageViewModel cocaColaPageViewModel)
	{
		InitializeComponent();
		BindingContext = cocaColaPageViewModel;
	}
}