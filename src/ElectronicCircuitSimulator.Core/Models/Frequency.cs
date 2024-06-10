using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class Frequency : IModel
{
    public double Value { get; set; }

    public HertzUnit Unit { get; set; }

    public Frequency(double value, HertzUnit hertzUnit)
    {
        Value = value;
        Unit = hertzUnit;
    }
}
