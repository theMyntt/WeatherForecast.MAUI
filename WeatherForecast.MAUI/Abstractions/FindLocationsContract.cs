using WeatherForecast.MAUI.Models;

namespace WeatherForecast.MAUI.Abstractions;

public abstract class FindLocationsContract
{
    public abstract Task<IEnumerable<FindLocationsDTO>?> Perform(FindLocationsDTO input);
    protected abstract Task<IEnumerable<FindLocationsDTO>?> ApplyInternalLogic(FindLocationsDTO input);
}