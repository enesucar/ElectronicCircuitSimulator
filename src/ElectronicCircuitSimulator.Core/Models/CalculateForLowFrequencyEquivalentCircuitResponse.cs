using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class CalculateForLowFrequencyEquivalentCircuitResponse : IResponse
{
    public Frequency Frequency_C1 { get; set; }

    public Frequency Frequency_C2 { get; set; }

    public Frequency Frequency_L { get; set; }

    public double VoltageGain { get; set; }

    public Resistance Resistance_Pi { get; set; }

    public double GMV_Pi { get; set; }

    public Resistance Resistance_B { get; set; }

    public CalculateForLowFrequencyEquivalentCircuitResponse()
    {
        Frequency_C1 = null!;
        Frequency_C2 = null!;
        Frequency_L = null!;
        Resistance_Pi = null!;
        Resistance_B = null!;
    }
}
