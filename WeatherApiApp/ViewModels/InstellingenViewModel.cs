using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.ViewModels
{
    public partial class InstellingenViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isToggled;

        public bool GetoggledDoorLaden = false;

        public InstellingenViewModel()
        {

            Title = "Instellingen";
            var Theme = Preferences.Get("Theme", "");
            if (!IsToggled)
            {
                if (Theme == "Dark")
                {
                    GetoggledDoorLaden = true;
                    IsToggled = true;
                }
            }
        }

        [RelayCommand]
        public void ToggleTheme()
        {
            var CurrentTheme = Application.Current.RequestedTheme;

            Application.Current.UserAppTheme = CurrentTheme.ToString() == "Light" ? AppTheme.Dark : AppTheme.Light;

            Preferences.Set("Theme", Application.Current.UserAppTheme.ToString());
        }

        [RelayCommand]
        public void SelectImageLight()
        {
            SelectImage(true);
        }

        [RelayCommand]
        public void SelectImageDark()
        {
            SelectImage(false);
        }

        private async void SelectImage(bool isLightTheme)
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Kies een achtergrondafbeelding",
                FileTypes = FilePickerFileType.Images

            });
            if (result == null)
                return;
            var FileName = result.FileName;
            var Stream = await result.OpenReadAsync();
            string MainDir = FileSystem.AppDataDirectory;

            using FileStream outputstream = new(Path.Combine(MainDir, FileName), FileMode.Create);
            await Stream.CopyToAsync(outputstream);
            outputstream.Close();

            Preferences.Set(isLightTheme ? "ImageLight" : "ImageDark", FileName);
        }
    }
}