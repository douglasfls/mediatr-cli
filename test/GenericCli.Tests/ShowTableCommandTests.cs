using System.Threading.Tasks;
using GenericCli.Providers;
using GenericCli.Services;
using GenericCli.Tests.MockProviders;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GenericCli.Tests;

public class ShowTableCommandTests
{
    private readonly ServiceProvider _provider;

    public ShowTableCommandTests()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IRandomProvider, RandomProviderMock>();
        services.AddScoped<IWeatherService, WeatherService>();
        _provider = services.BuildServiceProvider();
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Valid_Id_Is_Given_Result_Is_Not_Null()
    {
        const int validId = 1;
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityCode(validId);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Valid_Name_Is_Given_Result_Is_Not_Null()
    {
        const string validCity = "Porto";
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityName(validCity);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Near_Name_Is_Given_Result_Is_Not_Null()
    {
        const string validCity = "Porta";
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityName(validCity);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Query_All_Result_Is_Not_Empty()
    {
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeather();
        Assert.NotEmpty(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Invalid_Id_Is_Given_Result_Is_Null()
    {
        const int validId = 999;
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityCode(validId);
        Assert.Null(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Invalid_Name_Is_Given_Result_Is_Null()
    {
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityName(string.Empty);
        Assert.Null(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Null_Name_Is_Given_Result_Is_Null()
    {
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityName(string.Empty);
        Assert.Null(result);
    }

    [Fact]
    [Trait("Category", "Weather")]
    public async Task When_Far_Name_Is_Given_Result_Is_Null()
    {
        const string validCity = "Brasilia";
        var service = _provider.GetRequiredService<IWeatherService>();
        var result = await service.GetWeatherByCityName(validCity);
        Assert.Null(result);
    }
}