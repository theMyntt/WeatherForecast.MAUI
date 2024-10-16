using CommunityToolkit.Mvvm.ComponentModel;
using WeatherForecast.MAUI.Models;
using WeatherForecast.MAUI.Services;

namespace WeatherForecast.MAUI.ViewModels;

[QueryProperty("CityCode", "CityCode")]
public partial class ForecastViewModel : ObservableObject
{
    [ObservableProperty] private ForecastDTO? _location;
    [ObservableProperty] private int? _cityCode;

    private readonly ForecastService _service = new();

    public ForecastViewModel()
    {
        _ = GetLocationForecast();
    }

    public async Task GetLocationForecast()
    {
        Location = await _service.Perform(CityCode ?? 244);
    }
}