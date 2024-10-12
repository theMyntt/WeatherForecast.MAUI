using System.Text.Json;
using WeatherForecast.MAUI.Models;

namespace WeatherForecast.MAUI.Services;

public class ForecastService
{
    private readonly HttpClient _httpClient = new();

    private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
    
    public async Task<ForecastDTO?> Perform(int cityCode)
    {
        return await ApplyInternalLogic(cityCode);
    }

    private async Task<ForecastDTO?> ApplyInternalLogic(int cityCode)
    {
        Uri uri = new($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityCode}");

        var response = await _httpClient.GetAsync(uri);

        if (!response.IsSuccessStatusCode) return null;
        
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonSerializer.Deserialize<ForecastDTO>(json, _jsonOptions);
    }
}