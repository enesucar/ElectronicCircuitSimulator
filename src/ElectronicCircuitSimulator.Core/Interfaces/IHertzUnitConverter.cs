using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Core.Interfaces;

public interface IHertzUnitConverter
{
    double Convert(double value, HertzUnit fromHertzUnit, HertzUnit toHertzUnit);
}
