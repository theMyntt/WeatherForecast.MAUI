using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherForecast.MAUI.Abstractions;
using WeatherForecast.MAUI.Models;
using WeatherForecast.MAUI.Services;

namespace WeatherForecast.MAUI.ViewModels;

public partial class FindLocationsViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<FindLocationsDTO>? locations;
    
    public ICommand GetLocationsCommand { get; }

    private FindLocationsContract _service;

    public FindLocationsViewModel(FindLocationsContract service)
    {
        _service = service;
        GetLocationsCommand = new Command(GetLocations);
        GetLocations();
    }

    public async void GetLocations()
    {
        Locations = await _service.Perform();
    }
}