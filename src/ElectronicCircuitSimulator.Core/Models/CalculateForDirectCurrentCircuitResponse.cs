using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;

namespace ElectronicCircuitSimulator.Core.Models;

public class CalculateForDirectCurrentCircuitResponse : IResponse
{
    public Current Current_B { get; set; }

    public Current Current_C { get; set; }

    public Current Current_E { get; set; }

    public Voltage Voltage_CE { get; set; }

    public Voltage Voltage_CB { get; set; }

    public Voltage Voltage_BE { get; set; }

    public Voltage Voltage_B { get; set; }

    public OperationRegion OperationRegion { get; set; }

    public CalculateForDirectCurrentCircuitResponse()
    {
        Current_B = null!;
        Current_C = null!;
        Current_E = null!;
        Voltage_CE = null!;
        Voltage_CB = null!;
        Voltage_B = null!;
        Voltage_BE = null!;
    }
}
