using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.MAUI.Abstractions;
using WeatherForecast.MAUI.ViewModels;

namespace WeatherForecast.MAUI.Views;

public partial class FindLocations : ContentPage
{
    public FindLocations(FindLocationsContract service)
    {
        InitializeComponent();
        BindingContext = new FindLocationsViewModel(service);
    }
}