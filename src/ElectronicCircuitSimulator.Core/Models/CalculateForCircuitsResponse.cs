using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class CalculateForCircuitsResponse : IResponse
{
    public CalculateForDirectCurrentCircuitResponse CalculateForDirectCurrentCircuitResponse { get; set; }

    public CalculateForLowFrequencyEquivalentCircuitResponse CalculateForLowFrequencyEquivalentCircuitResponse { get; set; }

    public CalculateForCircuitsResponse()
    {
        CalculateForDirectCurrentCircuitResponse = null!;
        CalculateForLowFrequencyEquivalentCircuitResponse = null!;
    }
}
