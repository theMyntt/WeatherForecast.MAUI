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
    public ICommand ClearSearch { get; }
    public ICommand GoToForecast { get; }

    private readonly FindLocationsService _service;

    public FindLocationsViewModel()
    {
        _service = new();
        GetSpecific = new Command(async () => await GetSpecificLocation());
        ClearSearch = new Command(async () => await ClearFilters());
        GoToForecast = new Command<int>(async (int cityCode) => await NavigateToForecast(cityCode));
        _ = GetLocations();
    }

    private async Task GetLocations()
    {
        Locations = await _service.PerformFindAll();
    }

    private async Task NavigateToForecast(int cityCode)
    {
        await Shell.Current.GoToAsync($"Forecast?CityCode={cityCode}");
    }

    private async Task GetSpecificLocation()
    {
        if (string.IsNullOrEmpty(Query))
        {
            await GetLocations();
            return;
        }
        Locations = await _service.PerformFindSpecific(Query);
    }

    private async Task ClearFilters()
    {
        Query = "";
        Locations = await _service.PerformFindAll();
    }
}