using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class Current : IModel
{
    public double Value { get; set; }

    public AmperUnit Unit { get; set; }

    public Current(double value, AmperUnit amperUnit)
    {
        Value = value;
        Unit = amperUnit;
    }
}
