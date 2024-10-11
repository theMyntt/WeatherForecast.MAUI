using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using WeatherForecast.MAUI.Models;
using WeatherForecast.MAUI.Services;

namespace WeatherForecast.MAUI.ViewModels;

public partial class FindLocationsViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<FindLocationsDTO>? locations;
    [ObservableProperty] private string? query;
    
    public ICommand GetSpecific { get; }

    private readonly FindLocationsService _service;

    public FindLocationsViewModel()
    {
        _service = new();
        GetSpecific = new Command(async () => await GetSpecificLocation());
        _ = GetLocations();
    }

    private async Task GetLocations()
    {
        Locations = await _service.PerformFindAll();
    }

    private async Task GetSpecificLocation()
    {
        Locations = await _service.PerformFindSpecific(Query ?? "");
    }
}