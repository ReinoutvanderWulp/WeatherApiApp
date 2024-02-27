using WeatherApiApp.ViewModels;

namespace WeatherApiApp.Views;

public partial class InstellingenPage : ContentPage
{
    private InstellingenViewModel viewModel;

    public InstellingenPage(InstellingenViewModel vm)
    {
        InitializeComponent();
        BindingContext = viewModel = vm;
    }

    private void OnToggled(Object sender, ToggledEventArgs args)
    {
        if (!viewModel.GetoggledDoorLaden)
        {
            viewModel.ToggleTheme();
        }
        viewModel.GetoggledDoorLaden = false;
    }
}