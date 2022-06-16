namespace GenericCli.Providers;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime InstanceStart { get; }
    DateTime NowUtc { get; }
    DateTime InstanceStartUtc { get; }
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime InstanceStart { get; } = DateTime.Now;
    public DateTime NowUtc => DateTime.UtcNow;
    public DateTime InstanceStartUtc { get; } = DateTime.UtcNow;
}