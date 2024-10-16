using System;
using WeatherForecast.MAUI.ViewModels;

namespace WeatherForecast.MAUI.Views;

[QueryProperty(nameof(CityCode), "CityCode")]
public partial class Forecast : ContentPage
{
    private readonly ForecastViewModel _viewModel;

    public string? CityCode { get; set; }

    public Forecast()
    {
        InitializeComponent();
        _viewModel = new();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        if (CityCode != "" || CityCode != null)
        {
            _viewModel.CityCode = int.Parse(CityCode ?? "244");
        } 
        await _viewModel.GetLocationForecast();
        base.OnAppearing();
    }
}
