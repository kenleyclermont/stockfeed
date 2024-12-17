using StockFeed.ViewModels;
namespace StockFeed.Views;

public partial class AlibabaPage : ContentPage
{
	public AlibabaPage(AlibabaPageViewModel alibabaPageViewModel)
	{
		InitializeComponent();
		BindingContext = alibabaPageViewModel;
	}
}