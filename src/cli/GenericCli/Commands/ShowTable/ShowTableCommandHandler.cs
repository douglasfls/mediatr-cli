using ConsoleTables;
using GenericCli.Extensions;
using GenericCli.Services;

namespace GenericCli;

public class WeatherCommandHandler : LoggerWrapper<WeatherCommand>
{
    private readonly IWeatherService _weatherService;

    public WeatherCommandHandler(IWeatherService weatherService) => _weatherService = weatherService;

    public override async Task Execute(WeatherCommand notification, CancellationToken cancellationToken)
    {
        var rows = new List<Weather>();
        if (notification.CityCode.HasValue)
        {
            var item = await _weatherService.GetWeatherByCityCode(notification.CityCode.Value);
            if (item is not null) rows.Add(item);
        }
        else if (!string.IsNullOrEmpty(notification.CityName))
        {
            var item = await _weatherService.GetWeatherByCityName(notification.CityName);
            if (item is not null) rows.Add(item);
        }
        else
        {
            rows.AddRange(await _weatherService.GetWeather());
        }

        ConsoleTable
            .From(rows)
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(Format.Alternative);
    }
}
