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

    private FindLocationsService _service;

    public FindLocationsViewModel()
    {
        _service = new();
        GetLocationsCommand = new Command(async () => await GetLocations());
        _ = GetLocations();
    }

    public async Task GetLocations()
    {
        Locations = await _service.Perform();
    }
}