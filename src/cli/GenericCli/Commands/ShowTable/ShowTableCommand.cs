using CommandLine;
using MediatR;

namespace GenericCli;

[Verb("weather")]
public class WeatherCommand : BaseOptions, INotification
{
    [Option('c', "code")] public int? CityCode { get; set; }

    [Option('n', "name")] public string CityName { get; set; }
}