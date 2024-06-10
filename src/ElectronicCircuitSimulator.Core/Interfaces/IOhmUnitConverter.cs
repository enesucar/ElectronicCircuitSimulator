using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Core.Interfaces;

public interface IOhmUnitConverter
{
    double Convert(double value, OhmUnit fromOhmUnit, OhmUnit toOhmUnit);
}
