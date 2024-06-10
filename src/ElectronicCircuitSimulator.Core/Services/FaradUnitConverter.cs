using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Services;

public class FaradUnitConverter : UnitConverterBase, IFaradUnitConverter
{
    public double Convert(double value, FaradUnit fromVoltUnit, FaradUnit toVoltUnit)
    {
        var multipleDifference = ((byte)fromVoltUnit - (byte)toVoltUnit) * 3;
        return base.Convert(value, multipleDifference);
    }
}
