using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Core.Interfaces;

public interface IVoltUnitConverter
{
    double Convert(double value, VoltUnit fromVoltUnit, VoltUnit toVoltUnit);
}
