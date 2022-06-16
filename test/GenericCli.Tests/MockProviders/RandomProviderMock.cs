using GenericCli.Providers;

namespace GenericCli.Tests.MockProviders;

public class RandomProviderMock : IRandomProvider
{
    public double GetDouble()
    {
        return 1.1f;
    }

    public double GetDouble(int maxNumber)
    {
        return 2.2f;
    }

    public double GetDouble(int minNumber, int maxNumber)
    {
        return 3.3f;
    }

    public int GetInteger()
    {
        return 1;
    }

    public int GetInteger(int maxNumber)
    {
        return 2;
    }

    public int GetInteger(int minNumber, int maxNumber)
    {
        return 3;
    }
}