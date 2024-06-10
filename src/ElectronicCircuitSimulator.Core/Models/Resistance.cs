using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class Resistance : IModel
{
    public double Value { get; set; }

    public OhmUnit Unit { get; set; }

    public Resistance(double value, OhmUnit ohmUnit)
    {
        Value = value;
        Unit = ohmUnit;
    }
}
