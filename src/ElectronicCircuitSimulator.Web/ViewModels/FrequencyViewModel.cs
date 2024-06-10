using ElectronicCircuitSimulator.Core.Enums;

namespace ElectronicCircuitSimulator.Web.ViewModels;

public class FrequencyViewModel
{
    public double? Value { get; set; }

    public HertzUnit Unit { get; set; }

    public FrequencyViewModel()
    { }

    public FrequencyViewModel(double? value, HertzUnit hertzUnit)
    {
        Value = value;
        Unit = hertzUnit;
    }
}
