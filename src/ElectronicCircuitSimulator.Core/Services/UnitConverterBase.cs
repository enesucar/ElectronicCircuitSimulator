namespace ElectronicCircuitSimulator.Core.Services;

public abstract class UnitConverterBase
{
    protected virtual double Convert(double value, int multipleDifference)
    {
        return multipleDifference == 0 ? value : value * Math.Pow(10, multipleDifference);
    }
}
