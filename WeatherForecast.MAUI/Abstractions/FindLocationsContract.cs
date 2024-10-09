using System.Collections.ObjectModel;
using WeatherForecast.MAUI.Models;

namespace WeatherForecast.MAUI.Abstractions;

public abstract class FindLocationsContract
{
    public abstract Task<ObservableCollection<FindLocationsDTO>?> Perform();
    protected abstract Task<ObservableCollection<FindLocationsDTO>?> ApplyInternalLogic();
}