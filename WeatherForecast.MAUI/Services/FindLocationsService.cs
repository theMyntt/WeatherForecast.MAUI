using System.Collections.ObjectModel;
using System.Text.Json;
using WeatherForecast.MAUI.Models;

namespace WeatherForecast.MAUI.Services;

public class FindLocationsService
{
    private readonly HttpClient _httpClient = new();

    private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public async Task<ObservableCollection<FindLocationsDTO>?> PerformFindAll()
    {
        return await ApplyInternalLogicForFindAll();
    }

    private async Task<ObservableCollection<FindLocationsDTO>?> ApplyInternalLogicForFindAll()
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