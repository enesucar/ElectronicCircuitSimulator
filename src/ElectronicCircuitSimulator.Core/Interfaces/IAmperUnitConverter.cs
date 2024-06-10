using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Core.Interfaces;

public interface IAmperUnitConverter
{
    double Convert(double value, AmperUnit fromAmperUnit, AmperUnit toAmperUnit);
}
