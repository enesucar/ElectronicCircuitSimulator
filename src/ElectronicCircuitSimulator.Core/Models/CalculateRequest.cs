using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class CalculateRequest : IRequest
{
    public Resistance Resistance_g { get; set; }

    public Resistance Resistance_a { get; set; }

    public Resistance Resistance_b { get; set; }

    public Resistance Resistance_E { get; set; }

    public Resistance Resistance_y { get; set; }

    public Capacitance Capacitance_1 { get; set; }

    public Capacitance Capacitance_2 { get; set; }

    public Voltage Voltage_CC { get; set; }

    public Voltage Voltage_BE { get; set; }

    public double Beta_0 { get; set; }

    public CalculateRequest()
    {
        Resistance_g = null!;
        Resistance_a = null!;
        Resistance_b = null!;
        Resistance_E = null!;
        Resistance_y = null!;
        Capacitance_1 = null!;
        Capacitance_2 = null!;
        Voltage_CC = null!;
        Voltage_BE = null!;
    }
}
