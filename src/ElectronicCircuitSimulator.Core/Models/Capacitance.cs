using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class Capacitance : IModel
{
    public double Value { get; set; }

    public FaradUnit Unit { get; set; }

    public Capacitance(double value, FaradUnit faradUnit)
    {
        Value = value;
        Unit = faradUnit;
    } 
}
