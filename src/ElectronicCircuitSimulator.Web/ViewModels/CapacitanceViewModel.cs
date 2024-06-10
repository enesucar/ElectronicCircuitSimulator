using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Web.ViewModels;

public class CapacitanceViewModel
{
    public double? Value { get; set; }

    public FaradUnit Unit { get; set; }

    public CapacitanceViewModel()
    { }

    public CapacitanceViewModel(double? value, FaradUnit faradUnit)
    {
        Value = value;
        Unit = faradUnit;
    }
}
