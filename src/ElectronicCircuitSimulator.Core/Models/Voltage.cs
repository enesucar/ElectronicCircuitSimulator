using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class Voltage : IModel
{
    public double Value { get; set; }

    public VoltUnit Unit { get; set; }

    public Voltage(double value, VoltUnit voltUnit)
    {
        Value = value;
        Unit = voltUnit;
    }
}
