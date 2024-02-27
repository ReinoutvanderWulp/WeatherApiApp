using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        public string achtergrondAfbeelding;

        public bool IsNotBusy => !IsBusy;

        [RelayCommand]
        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        public void SetTheme()
        {
            var StartTheme = Preferences.Get("Theme", "");
            string MainDir = FileSystem.AppDataDirectory;
            var FileName = StartTheme == "Dark" ? Preferences.Get("ImageDark", "") : Preferences.Get("ImageLight", "");
            Application.Current.UserAppTheme = StartTheme == "Dark" ? AppTheme.Dark : AppTheme.Light;

            if (FileName != null)
            {
                AchtergrondAfbeelding = Path.Combine(MainDir, FileName);
            }
        }
    }
}