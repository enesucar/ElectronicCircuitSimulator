using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Services;

public class VoltUnitConverter : UnitConverterBase, IVoltUnitConverter
{
    public double Convert(double value, VoltUnit fromVoltUnit, VoltUnit toVoltUnit)
    {
        var multipleDifference = ((byte)fromVoltUnit - (byte)toVoltUnit) * 3;
        return base.Convert(value, multipleDifference);
    }
}
