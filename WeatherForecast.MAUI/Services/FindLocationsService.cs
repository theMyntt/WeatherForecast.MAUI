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

    public override async Task<IEnumerable<FindLocationsDTO>?> Perform(FindLocationsDTO input)
    {
        return await ApplyInternalLogic(input);
    }

    protected override async Task<IEnumerable<FindLocationsDTO>?> ApplyInternalLogic(FindLocationsDTO input)
    {
        IEnumerable<FindLocationsDTO>? location = new List<FindLocationsDTO>();

        Uri uri = new("https://brasilapi.com.br/api/cptec/v1/cidade");

        var response = await _httpClient.GetAsync(uri);

        if (!response.IsSuccessStatusCode) return location;

        var json = await response.Content.ReadAsStringAsync();
        location = JsonSerializer.Deserialize<IEnumerable<FindLocationsDTO>>(json);

        return location;
    }
}