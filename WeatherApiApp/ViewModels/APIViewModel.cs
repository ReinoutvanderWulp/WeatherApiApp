using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApiApp.Models;

namespace WeatherApiApp.ViewModels
{
    public partial class APIViewModel : BaseViewModel
    {
        WeerData weerData = new();

        [ObservableProperty]
        private Chart grafiek;

        private List<ChartEntry> entries = new();
        WeerData WeerData = new();

        public APIViewModel() { }

        [RelayCommand]
        public async void WeerOpvragen()
        {
            var apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=51.1656&longitude=4.9892&hourly=temperature_2m";

            try
            {
                var response = await HttpClient.GetStringAsync(apiUrl);
                WeerData = JsonSerializer.Deserialize<WeerData>(response);

                var aantal = WeerData.hourly.temperature_2m.Count;

                for (var i = 0; i < aantal; i++)
                {
                    var label = i % 10 == 0 ? WeerData.hourly.time[i].ToString() : "";
                    var valueLabel = i % 10 == 0 ? WeerData.hourly.temperature_2m[i].ToString() : "";
                    entries.Add(new ChartEntry((WeerData.hourly.temperature_2m[i])) { Label = label, ValueLabel = valueLabel });
                }

                Grafiek = new LineChart
                {
                    Entries = entries,
                    LineMode = LineMode.Straight,
                    PointMode = PointMode.Circle,
                    PointSize = 0,
                    /*ValueLabelOption = ValueLabelOption.None,
                    ShowYAxisText = true,
                    ShowYAxisLines = true,
                    YAxisPosition = Position.Left*/
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}