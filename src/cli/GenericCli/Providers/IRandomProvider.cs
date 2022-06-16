namespace GenericCli.Providers;

public interface IRandomProvider
{
    double GetDouble();
    double GetDouble(int maxNumber);
    double GetDouble(int minNumber, int maxNumber);
    int GetInteger();
    int GetInteger(int maxNumber);
    int GetInteger(int minNumber, int maxNumber);
}

public class RandomProvider : IRandomProvider
{
    private readonly Random _random;

    public RandomProvider()
    {
        _random = new Random();
    }

    public int GetInteger()
    {
        return _random.Next();
    }

    public int GetInteger(int maxNumber)
    {
        return _random.Next(maxNumber);
    }

    public int GetInteger(int minNumber, int maxNumber)
    {
        return _random.Next(minNumber, maxNumber);
    }

    public double GetDouble()
    {
        return GetInteger() + _random.NextDouble();
    }

    public double GetDouble(int maxNumber)
    {
        return GetInteger(maxNumber) + _random.NextDouble();
    }

    public double GetDouble(int minNumber, int maxNumber)
    {
        return GetInteger(minNumber, maxNumber) + _random.NextDouble();
    }
}