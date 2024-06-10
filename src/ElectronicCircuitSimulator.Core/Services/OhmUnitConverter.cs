using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Services;

public class OhmUnitConverter : UnitConverterBase, IOhmUnitConverter
{
    public double Convert(double value, OhmUnit fromOhmUnit, OhmUnit toOhmUnit)
    {
        var multipleDifference = ((byte)fromOhmUnit - (byte)toOhmUnit) * 3;
        return base.Convert(value, multipleDifference);
    }
}
