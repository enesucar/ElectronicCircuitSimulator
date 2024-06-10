using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Services;

public class AmperUnitConverter : UnitConverterBase, IAmperUnitConverter
{
    public double Convert(double value, AmperUnit fromAmperUnit, AmperUnit toAmperUnit)
    {
        var multipleDifference = ((byte)fromAmperUnit - (byte)toAmperUnit) * 3;
        return base.Convert(value, multipleDifference);
    }
}

