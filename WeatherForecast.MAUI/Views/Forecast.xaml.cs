using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.MAUI.ViewModels;

namespace WeatherForecast.MAUI.Views;

public partial class Forecast : ContentPage
{
    public Forecast()
    {
        InitializeComponent();
        BindingContext = new ForecastViewModel();
    }
}