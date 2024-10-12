using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.MAUI.ViewModels;

namespace WeatherForecast.MAUI.Views;

public partial class Forecast : ContentPage
{
    private readonly ForecastViewModel _viewModel;
    
    public Forecast()
    {
        InitializeComponent();
        _viewModel = new();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        await _viewModel.GetLocationForecast();
        base.OnAppearing();
    }
}