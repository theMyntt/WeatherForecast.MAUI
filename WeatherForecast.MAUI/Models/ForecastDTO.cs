namespace WeatherForecast.MAUI.Models;

public record ForecastDTO(
    string Cidade,
    string Estado,
    string Atualizado_em,
    IEnumerable<WheaterModel> Clima);

public record WheaterModel(
    string Data,
    string Condicao,
    string Condicao_desc,
    int Min,
    int Max,
    int Indice_uv); 