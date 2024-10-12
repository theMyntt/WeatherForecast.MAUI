using CommunityToolkit.Mvvm.ComponentModel;
using WeatherForecast.MAUI.Models;
using WeatherForecast.MAUI.Services;

namespace WeatherForecast.MAUI.ViewModels;

public partial class ForecastViewModel : ObservableObject
{
    [ObservableProperty] private ForecastDTO? _location;

    private readonly ForecastService _service = new();

    public ForecastViewModel()
    {
        _ = GetLocationForecast();
    }

    private async Task GetLocationForecast()
    {
        Location = await _service.Perform(244);
    }
}