using ElectronicCircuitSimulator.Core.Models;

namespace ElectronicCircuitSimulator.Core.Interfaces;

public interface IElectricCircuitCalculator
{
    CalculateForCircuitsResponse Calculate(CalculateRequest calculateRequest);
}
