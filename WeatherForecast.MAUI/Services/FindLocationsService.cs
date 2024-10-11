using System.Collections.ObjectModel;
using System.Text.Json;
using WeatherForecast.MAUI.Abstractions;
using WeatherForecast.MAUI.Models;

namespace WeatherForecast.MAUI.Services;

public class FindLocationsService : FindLocationsContract
{
    private HttpClient _httpClient = new();

    private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public override async Task<ObservableCollection<FindLocationsDTO>?> Perform()
    {
        return await ApplyInternalLogic();
    }

    protected override async Task<ObservableCollection<FindLocationsDTO>?> ApplyInternalLogic()
    {
        ObservableCollection<FindLocationsDTO>? location = [];

        Uri uri = new("https://brasilapi.com.br/api/cptec/v1/cidade");

        var response = await _httpClient.GetAsync(uri);

        if (!response.IsSuccessStatusCode) return location;

        var json = await response.Content.ReadAsStringAsync();
        location = JsonSerializer.Deserialize<ObservableCollection<FindLocationsDTO>>(json, _jsonOptions);

        return location;
    }
}