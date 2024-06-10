using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Web.ViewModels;

public class CurrentViewModel
{
    public double? Value { get; set; }

    public AmperUnit Unit { get; set; }

    public CurrentViewModel()
    { }

    public CurrentViewModel(double? value, AmperUnit amperUnit)
    {
        Value = value;
        Unit = amperUnit;
    }
}
