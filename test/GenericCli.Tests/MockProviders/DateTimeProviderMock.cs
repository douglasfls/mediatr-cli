using System;
using GenericCli.Providers;

namespace GenericCli.Tests.MockProviders;

public class DateTimeProviderMock : IDateTimeProvider
{
    public DateTime Now => new(2022, 1, 1, 13, 30, 0);

    public DateTime InstanceStart => new(2022, 1, 1, 13, 0, 0);

    public DateTime NowUtc => new DateTime(2022, 1, 1, 13, 30, 0).ToUniversalTime();

    public DateTime InstanceStartUtc => new DateTime(2022, 1, 1, 13, 0, 0).ToUniversalTime();
}