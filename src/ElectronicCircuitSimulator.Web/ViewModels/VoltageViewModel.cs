using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Web.ViewModels;

public class VoltageViewModel
{
    public double? Value { get; set; }

    public VoltUnit Unit { get; set; }

    public VoltageViewModel()
    { }

    public VoltageViewModel(double? value, VoltUnit voltUnit)
    {
        Value = value;
        Unit = voltUnit;
    }
}
