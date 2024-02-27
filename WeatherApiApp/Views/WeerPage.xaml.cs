using WeatherApiApp.ViewModels;

namespace WeatherApiApp.Views;

public partial class WeerPage : ContentPage
{
	private APIViewModel viewModel;
	public WeerPage(APIViewModel vm)
	{
		InitializeComponent();
		BindingContext = viewModel = vm;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.SetTheme();
    }
}