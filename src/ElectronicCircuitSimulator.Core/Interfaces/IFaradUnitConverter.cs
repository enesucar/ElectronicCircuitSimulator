using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Core.Interfaces;

public interface IFaradUnitConverter
{
    double Convert(double value, FaradUnit fromFaradUnit, FaradUnit toFaradUnit);
}
