using System.Collections.ObjectModel;
using WeatherForecast.MAUI.Models;

namespace WeatherForecast.MAUI.Abstractions;

public abstract class FindLocationsContract
{
    public abstract Task<ObservableCollection<FindLocationsDTO>?> Perform(FindLocationsDTO input);
    protected abstract Task<ObservableCollection<FindLocationsDTO>?> ApplyInternalLogic(FindLocationsDTO input);
}