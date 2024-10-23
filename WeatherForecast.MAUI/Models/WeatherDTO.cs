using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.MAUI.Models
{
    public record BaseForecastDTO(
        CoordDTO Coord,
        IEnumerable<WeatherDTO> Weather,
        string Base,
        MainDTO Main,
        int Visibility,
        WindDTO Wind,
        CloudsDTO Clouds, 
        int Dt,
        int Timezone,
        int Id,
        string Name,
        int Cod);

    public record CoordDTO(
        int Lon,
        int Lat);

    public record WeatherDTO(
        int Id,
        string Main,
        string Description);

    public record MainDTO(
        int Temp,
        int Feels_like,
        int Temp_min,
        int Temp_max,
        int Pressure,
        int Humidity,
        int Sea_level,
        int Grnd_level);

    public record WindDTO(
        int Speed,
        int Deg);

    public record CloudsDTO(
        int All);

    public record SysDTO(
        int Type,
        int Id,
        string Country,
        int Sunrise,
        int Sunset);
}
