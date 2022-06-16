using GenericCli.Providers;

namespace GenericCli.Services;

public interface IWeatherService
{
    Task<Weather[]> GetWeather();
    Task<Weather> GetWeatherByCityCode(int cityCode);
    Task<Weather> GetWeatherByCityName(string cityName);
}

public class WeatherService : IWeatherService
{
    private readonly IRandomProvider _randomProvider;

    public WeatherService(IRandomProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public async Task<Weather[]> GetWeather()
    {
        var result = new Weather[]
        {
            new()
            {
                CityCode = 1, Name = "Porto", Country = "Portugal", Temperature = _randomProvider.GetDouble(-10, 30)
            },
            new()
            {
                CityCode = 2, Name = "Lisboa", Country = "Portugal", Temperature = _randomProvider.GetDouble(-10, 30)
            },
            new()
            {
                CityCode = 3, Name = "Aveiro", Country = "Portugal", Temperature = _randomProvider.GetDouble(-10, 30)
            },
            new()
            {
                CityCode = 4, Name = "Braga", Country = "Portugal", Temperature = _randomProvider.GetDouble(-10, 30)
            },
            new()
            {
                CityCode = 4, Name = "Vigo", Country = "Espanha", Temperature = _randomProvider.GetDouble(-10, 30)
            },
            new()
            {
                CityCode = 5, Name = "Porta", Country = "Espanha", Temperature = _randomProvider.GetDouble(-10, 30)
            },
            new ()
            {
                CityCode = 5, Name = "Portas", Country = "Espanha", Temperature = _randomProvider.GetDouble(-10, 30)
            }
        };
        return await Task.FromResult(result);
    }

    public async Task<Weather> GetWeatherByCityCode(int cityCode)
    {
        var weathers = await GetWeather();
        return weathers.FirstOrDefault(p => p.CityCode == cityCode);
    }

    public async Task<Weather> GetWeatherByCityName(string cityName)
    {
        if (string.IsNullOrEmpty(cityName)) return default;
        var weathers = await GetWeather();
        var query = weathers.Select(
            p => new { distance = LevenshteinDistance.Calculate(p.Name, cityName), weather = p });

        return query.Where(p => p.distance <= 1).MinBy(p => p.distance)?.weather;
    }
}