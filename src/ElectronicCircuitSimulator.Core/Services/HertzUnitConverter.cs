using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Services;

public class HertzUnitConverter : UnitConverterBase, IHertzUnitConverter
{
    public double Convert(double value, HertzUnit fromHertzUnit, HertzUnit toHertzUnit)
    {
        var multipleDifference = ((byte)fromHertzUnit - (byte)toHertzUnit) * 3;
        return base.Convert(value, multipleDifference);
    }
}
